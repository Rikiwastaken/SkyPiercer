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
    private void Start()
    {
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
        currentHP = maxHP;
        player = GameObject.FindAnyObjectByType<playermvt>().transform;
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
    }

}
