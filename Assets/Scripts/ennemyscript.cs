using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyscript : MonoBehaviour
{
    public int currentHP;
    public int maxHP;
    public List<GameObject> ennemygroup;
    public float detectray;

    private SceneInfo sceneInfo;
    private Transform player;
    public float movespeed;

    [Header("Moves")]

    public List<Art> MoveIdList;

    [Header("AutoAttack")]
    public int BaseDamage;
    public float AutoAttackCD;
    public int AutoAttackCounter;
    public float autoattackrange;
    public GameObject target;

    private void Start()
    {
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
        currentHP = maxHP;
        player = GameObject.FindAnyObjectByType<playermvt>().transform;
        RandomizeCD();
    }

    private void FixedUpdate()
    {

        if(player != null)
        {
            if(Vector3.Distance(player.position,transform.position) <= detectray && !sceneInfo.incombat)
            {
                sceneInfo.incombat = true;
                sceneInfo.enemylist = ennemygroup;
            }
        }

        if(currentHP <= 0)
        {
            sceneInfo.enemylist.Remove(gameObject);
            if (sceneInfo.enemylist.Count == 0)
            {
                sceneInfo.incombat=false;
            }
            Destroy(gameObject);
        }

        if(sceneInfo.incombat && sceneInfo.enemylist.Contains(gameObject))
        {
            if (target == null)
            {
                target = GameObject.FindFirstObjectByType<CombatCharacter>().gameObject;
            }
            ManageAutoAttack();
            ManageArts();
            
            transform.forward = target.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            if (Vector2.Distance(target.transform.position, transform.position) > autoattackrange)
            {
                GetComponent<Rigidbody>().velocity = movespeed * (target.transform.position - transform.position) / Vector3.Magnitude(target.transform.position - transform.position);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }



    }

    private void ManageAutoAttack()
    {
        
        if (AutoAttackCounter > 0)
        {
            AutoAttackCounter--;
        }
        else if (Vector3.Distance(target.transform.position, transform.position) <= autoattackrange)
        {
            target.GetComponent<CombatCharacter>().CurrentHP -= BaseDamage;
            AutoAttackCounter = (int)(AutoAttackCD / Time.deltaTime);
            sceneInfo.SpawnDamageText(BaseDamage, new Color(0.9f, 0f, 0f));
        }
    }

    private void RandomizeCD()
    {
        foreach (Art art in MoveIdList)
        {
            art.cooldowncounter = (int)Random.Range(10,art.cooldown);
        }
    }

    private void ManageArts()
    {
        foreach (Art art in MoveIdList)
        {
            
            if (art.cooldowncounter == 0 && Vector2.Distance(target.transform.position, transform.position) <= art.range)
            {
                art.cooldowncounter = (int)(art.cooldown / Time.deltaTime);
                target.GetComponent<CombatCharacter>().CurrentHP -= (int)(BaseDamage * art.multiplier);
                sceneInfo.SpawnDamageText((int)(BaseDamage * art.multiplier), new Color(0.886f, 0.5446f, 0f));
            }
            else if(art.cooldowncounter > 0)
            {
                art.cooldowncounter--;
            }
        }

    }

}
