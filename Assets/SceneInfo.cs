using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    public bool incombat;
    public List<GameObject> enemylist;
    public GameObject focus;

    private void FixedUpdate()
    {
        if(!incombat && focus!=null)
        {
            focus = null;
        }
    }

}
