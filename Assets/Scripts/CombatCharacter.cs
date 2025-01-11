using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class Art
{
    public float cooldown;
    public float cooldowncounter;
    public string name;
    public float multiplier;
    public float range;
    public Sprite Sprite;
    public int binding; // 1: left trigger, 2: left bumper, 3 : right bumper; 4 : right trigger
    public GameObject icon;
}

public class CombatCharacter : MonoBehaviour
{

    [Header("HP")]
    public float CurrentHP;
    public int MaxHP;
    public float regenoutofcombat;

    [Header("Moves")]
    
    public List<Art> MoveIdList;


    [Header("AutoAttack")]
    public int BaseDamage;
    public float AutoAttackCD;
    public int AutoAttackCounter;
    public float autoattackrange;

    [Header("Inputs")]
    float valueLeftTrigger;
    float valueRightTrigger;
    float valueLeftBumper;
    float valueRightBumper;

    private SceneInfo sceneInfo;

    void Start()
    {
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInputs();
        if (sceneInfo.incombat)
        {
            ManageCD();
            ManageAutoAttack();
            ManageArts();
        }
        else
        {
            foreach (Art art in MoveIdList)
            {
                art.cooldowncounter = 0;
            }
            if(CurrentHP<MaxHP)
            {
                CurrentHP += regenoutofcombat * Time.fixedDeltaTime;
            }
            
        }
        



    }

    private void ManageCD()
    {
        for (int i = 0; i < MoveIdList.Count; i++)
        {
            if(MoveIdList[i].cooldowncounter > 0)
            {
                MoveIdList[i].cooldowncounter --;
            }
        }
    }

    private void GetInputs()
    {
        valueLeftTrigger = sceneInfo.GetComponent<InputsManager>().valueLeftTrigger;
        valueRightTrigger = sceneInfo.GetComponent<InputsManager>().valueRightTrigger;
        valueLeftBumper = sceneInfo.GetComponent<InputsManager>().valueLeftBumper;
        valueRightBumper = sceneInfo.GetComponent<InputsManager>().valueRightBumper;
    }

    private void ManageAutoAttack()
    {

        if(AutoAttackCounter>0)
        {
            AutoAttackCounter--;
        }
        else if(Vector3.Distance(sceneInfo.focus.transform.position,transform.position)<=autoattackrange)
        {
            sceneInfo.focus.GetComponentInChildren<ennemyscript>().currentHP-=BaseDamage;
            AutoAttackCounter = (int)(AutoAttackCD/Time.deltaTime);
            sceneInfo.SpawnDamageText(BaseDamage, false);
        }
    }

    private void ManageArts()
    {
        foreach(Art art in MoveIdList)
        {
            float correctinput = 0;
            if(art.binding==1)
            {
                correctinput = valueLeftTrigger;
            }
            else if (art.binding == 2)
            {
                correctinput += valueLeftBumper;
            }
            else if (art.binding == 3)
            {
                correctinput += valueRightTrigger;
            }
            else if (art.binding==4)
            {
                correctinput = valueRightBumper;
            }
            if (correctinput == 1 && art.cooldowncounter==0 && Vector2.Distance(sceneInfo.focus.transform.position,transform.position)<=art.range)
            {
                art.cooldowncounter= (int)(art.cooldown/Time.deltaTime);
                sceneInfo.focus.GetComponent<ennemyscript>().currentHP-=(int)(BaseDamage*art.multiplier);
                sceneInfo.SpawnDamageText((int)(BaseDamage * art.multiplier), new Color(0.886f,0.5446f,0f), true);
            }
        }
        
    }

}
