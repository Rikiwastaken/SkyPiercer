using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatText : MonoBehaviour
{

    public float timebeforefade;
    public float upspeed;

    private int framesbeforefade;

    private GameObject Cam;

    private SceneInfo sceneInfo;
    void Start()
    {

        Cam = GameObject.Find("Main Camera");
        framesbeforefade = (int)(timebeforefade/Time.deltaTime);
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.forward = Cam.transform.forward;
        transform.position += new Vector3(0f, upspeed, 0f)*Time.fixedDeltaTime;
        if(framesbeforefade > 0 )
        {
            framesbeforefade--;
        }
        else
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.identity;
        if(!sceneInfo.incombat)
        {
            Destroy(gameObject);
        }
    }
}
