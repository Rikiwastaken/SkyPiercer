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
    public Sprite Sprite;
    public int binding; // 1: left trigger, 2: left bumper, 3 : right bumper; 4 : right trigger
}

public class CombatCharacter : MonoBehaviour
{

    


    [Header("HP")]
    public int CurrentHP;
    public int MaxHP;

    [Header("Moves")]
    
    public List<Art> moveIDlist;
    private List<int> moveCDlist;


    [Header("AutoAttack")]
    public int BaseDamage;
    public float AutoAttackCD;
    public int AutoAttackCounter;
    public float autoattackrange;

    private SceneInfo sceneInfo;

    void Start()
    {
        moveCDlist = new List<int>(moveIDlist.Count);
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sceneInfo.incombat)
        {
            ManageCD();
            ManageAutoAttack();
        }
        



    }

    private void ManageCD()
    {
        for (int i = 0; i < moveCDlist.Count; i++)
        {
            if(moveCDlist[i] >= 0)
            {
                moveCDlist[i] --;
            }
        }
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
            sceneInfo.SpawnDamageText(BaseDamage, sceneInfo.focus);
        }
    }

    

}
