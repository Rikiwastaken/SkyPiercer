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
    private void Start()
    {
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
        currentHP = maxHP;
        GetComponent<SphereCollider>().radius= detectray;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        Debug.Log(Mathf.Abs(collision.transform.position.y - transform.position.y));
        Debug.Log(collision.GetComponent<playermvt>());
        if (Mathf.Abs(collision.transform.position.y-transform.position.y) <2 && collision.GetComponent<playermvt>())
        {
            
            if (!sceneInfo.incombat)
            {
                sceneInfo.incombat = true;
                sceneInfo.enemylist = ennemygroup;
            }
        }
    }

    private void FixedUpdate()
    {
        if(currentHP == 0)
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
