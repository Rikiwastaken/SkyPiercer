using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        ManageHPSlider();



    }

    private void ManageHPSlider()
    {
        if(sceneInfo.incombat)
        {
            GetComponentInChildren<Canvas>().enabled=true;
            GetComponentInChildren<Slider>().value = (float)currentHP/(float)maxHP;
            GetComponentInChildren<Canvas>().transform.forward = GameObject.FindAnyObjectByType<Camera>().transform.forward;
        }
        else
        {
            GetComponentInChildren<Canvas>().enabled = false;
        }
    }

    private void ManageAutoAttack()
    {
        
        if (AutoAttackCounter > 0)
        {
            AutoAttackCounter--;
        }
        else if (Vector3.Distance(target.transform.position, transform.position) <= autoattackrange*1.8f)
        {
            target.GetComponent<CombatCharacter>().CurrentHP -= BaseDamage;
            AutoAttackCounter = (int)(AutoAttackCD / Time.deltaTime);
            sceneInfo.SpawnDamageText(BaseDamage, new Color(0.9f, 0f, 0f), false);
        }
    }

    private void RandomizeCD()
    {
        foreach (Art art in MoveIdList)
        {
            art.cooldowncounter = (int)(Random.Range(5,art.cooldown)/Time.fixedDeltaTime);
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
                sceneInfo.SpawnDamageText((int)(BaseDamage * art.multiplier), new Color(0.9f, 0f, 0f), true);
            }
            else if(art.cooldowncounter > 0)
            {
                art.cooldowncounter--;
            }
        }

    }

}
