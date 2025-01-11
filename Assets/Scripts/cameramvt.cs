using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracam : MonoBehaviour
{

    Controls controls;

    public GameObject Player;
    public float mousespeed;
    public float orbitDamping;

    private Vector3 localRot;

    private Vector2 camstick;

    float valueRightStickleft;
    float valueRightStickright;
    float valueRightStickup;
    float valueRightStickdown;

    GameObject focus;

    private SceneInfo sceneInfo;

    void Awake()
    {
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInputs();
        updatecontrols(valueRightStickright, valueRightStickleft, valueRightStickup, valueRightStickdown);
        if(sceneInfo.incombat)
        {
            if(sceneInfo.focus ==null)
            {
                foreach(GameObject ennemy in sceneInfo.enemylist)
                {
                    if(sceneInfo.focus == null)
                    {
                        sceneInfo.focus = ennemy;
                    }
                    else if(Vector2.Distance(sceneInfo.focus.transform.position,Player.transform.position)> Vector2.Distance(sceneInfo.focus.transform.position, ennemy.transform.position))
                    {
                        sceneInfo.focus = ennemy;
                    }
                }
               
            }
            transform.position = Player.transform.position + new Vector3(0f,1f,0f);
            transform.forward = sceneInfo.focus.transform.position - transform.position;

        }
        else
        {
            transform.position = Player.transform.position;

            localRot.x += camstick.x * mousespeed;
            localRot.y -= camstick.y * mousespeed;

            localRot.y = Mathf.Clamp(localRot.y, -10f, 80f);

            Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
        }
        

    }

    void GetInputs()
    {
        valueRightStickdown = sceneInfo.GetComponent<InputsManager>().valueRightStickdown;
        valueRightStickup = sceneInfo.GetComponent<InputsManager>().valueRightStickup;
        valueRightStickleft = sceneInfo.GetComponent<InputsManager>().valueRightStickleft;
        valueRightStickright = sceneInfo.GetComponent<InputsManager>().valueRightStickright;
    }
    void updatecontrols(float valueright, float valueleft, float valueup, float valuedown)
    {
        if (valueleft == 0 && valueright == 0)
        {
            camstick.x = 0;
        }
        else if (valueleft == 0 && valueright == 1)
        {
            camstick.x = 1;
        }
        else if (valueright == 0 && valueleft == 1)
        {
            camstick.x = -1;
        }

        if (valuedown == 0 && valueup == 0)
        {
            camstick.y = 0;
        }
        else if (valuedown == 0 && valueup == 1)
        {
            camstick.y = 1;
        }
        else if (valueup == 0 && valuedown == 1)
        {
            camstick.y = -1;
        }
    }
}
