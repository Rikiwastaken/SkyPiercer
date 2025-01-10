using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    [Header("HP")]
    public int CurrentHP;
    public int MaxHP;

    [Header("Moves")]
    public List<int> moveIDlist;
    private List<int> moveCDlist;


    [Header("AutoAttack")]
    public int BaseDamage;
    public float AutoAttackCD;
    public int AutoAttackCounter;
    public float autoattackrange;

    private SceneInfo sceneInfo;
    public GameObject TextPopUp;

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
            SpawnDamageText(BaseDamage, sceneInfo.focus);
        }
    }

    private void SpawnDamageText(float damage, GameObject target)
    {
        Vector3 newposition = target.transform.position + new Vector3(Random.Range(0f,0.5f), 1+Random.Range(0f, 0.5f), Random.Range(0f, 0.5f));
        GameObject newtext = Instantiate(TextPopUp, newposition, Quaternion.identity);
        newtext.GetComponent<TextMeshPro>().text = ""+(int)damage;
    }

}
