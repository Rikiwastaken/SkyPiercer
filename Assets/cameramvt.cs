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

    float valueleft;
    float valueright;
    float valueup;
    float valuedown;

    GameObject focus;

    private SceneInfo sceneInfo;

    void Awake()
    {
        controls = new Controls();
        controls.gameplay.camleft.performed += ctx => valueleft = 1;
        controls.gameplay.camright.performed += ctx => valueright = 1;
        controls.gameplay.camleft.canceled += ctx => valueleft = 0;
        controls.gameplay.camright.canceled += ctx => valueright = 0;
        controls.gameplay.camdown.performed += ctx => valuedown = 1;
        controls.gameplay.camdown.canceled += ctx => valuedown = 0;
        controls.gameplay.camup.performed += ctx => valueup = 1;
        controls.gameplay.camup.canceled += ctx => valueup = 0;
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        updatecontrols(valueright, valueleft, valueup, valuedown);
        if(sceneInfo.incombat)
        {
            if(focus ==null)
            {
                foreach(GameObject ennemy in sceneInfo.enemylist)
                {
                    if(focus == null)
                    {
                        focus = ennemy;
                    }
                    else if(Vector2.Distance(focus.transform.position,Player.transform.position)> Vector2.Distance(focus.transform.position, ennemy.transform.position))
                    {
                        focus = ennemy;
                    }
                }
               
            }
            transform.position = Player.transform.position + new Vector3(0f,1f,0f);
            transform.forward = focus.transform.position - transform.position;

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
    void OnEnable()
    {
        controls.gameplay.Enable();
    }
    void OnDisable()
    {
        controls.gameplay.Disable();
    }
}
