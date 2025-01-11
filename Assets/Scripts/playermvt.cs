using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playermvt : MonoBehaviour
{
    private Rigidbody rb;

    public Transform cam;

    [Header("Movement Variables")]
    public float maxvel;

    public float slowdownx;
    public float slowdownz;

    public float rotspeed;


    [Header("Grappling Variables")]
    public float grapspeed;
    private GameObject grapplepoint;
    private bool grapkeypressed;


    [Header("Jump Variables")]
    public float jumpstr;

    public int jumpduration;
    public int jumpcnt;

    public float jumpdownforce;

    public Transform groundcheck;
    public float gcradius;

    public bool grounded;

    public LayerMask whatisground;

    private Vector2 mvtstick;

    float valueLeftStickleft;
    float valueLeftStickright;
    float valueLeftStickup;
    float valueLeftStickdown;
    float valueButtonSouth;
    float valueLeftTrigger;
    float valueRightTrigger;
    float valueLeftBumper;
    float valueRightBumper;

    public int collidingx;
    public int collidingz;

    private float lastvely;

    [Header("Combat Variables")]
    public SceneInfo sceneInfo;

    void Awake()
    {

        rb = GetComponent<Rigidbody>();
        sceneInfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInputs();
        if (jumpcnt > 0)
        {
            jumpcnt--;
        }

        checkwalls();

        if(collidingx==0 && collidingz == 0)
        {
            lastvely=rb.velocity.y;
        }


        if (grapkeypressed && valueLeftTrigger==0)
        {
            grapkeypressed = false;
        }

        if (grounded)
        {
            GetComponent<Grapplefind>().ReinitGrapples();
        }

        if (GetComponent<Grapplefind>().activegrapple != null && valueLeftTrigger==1 && !grapkeypressed && !GetComponent<Grapplefind>().grappling && !sceneInfo.incombat)
        {
            GetComponent<Grapplefind>().grappling = true;
        }

        if(GetComponent<Grapplefind>().grappling)
        {
            grapplepoint = GetComponent<Grapplefind>().activegrapple;

            Vector3 movedir = grapplepoint.transform.position - (transform.position + new Vector3(0, 1, 0));
            movedir.Normalize();
            movedir = movedir * grapspeed;


            rb.velocity = new Vector3(movedir.x, movedir.y, movedir.z);

            if (Vector3.Distance(transform.position + new Vector3(0, 1, 0),grapplepoint.transform.position) <1)
            {
                GetComponent<Grapplefind>().grappling = false;
                grapplepoint.GetComponent<GrapplePoint>().alreadyused = true;
                rb.velocity = new Vector3(0,15,0);
                grapkeypressed = true;
            }
            if (rb.velocity.x != 0 && rb.velocity.z != 0)
            {
                transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }
        else
        {
           

            movement();

            Collider[] colliders = Physics.OverlapSphere(groundcheck.position, gcradius, whatisground);

            if (colliders.Length > 0)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }

            if (valueButtonSouth != 0 && grounded && jumpcnt == 0 && !sceneInfo.incombat)
            {
                jumpcnt = jumpduration;
                //rb.AddForce(new Vector3(0, jumpstr, 0));
                rb.velocity = new Vector3(rb.velocity.x, jumpstr, rb.velocity.z);
            }
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundcheck.position, gcradius);
    }

    void GetInputs()
    {
        valueLeftStickleft = sceneInfo.GetComponent<InputsManager>().valueLeftStickleft;
        valueLeftStickright = sceneInfo.GetComponent<InputsManager>().valueLeftStickright;
        valueLeftStickdown = sceneInfo.GetComponent<InputsManager>().valueLeftStickdown;
        valueLeftStickup = sceneInfo.GetComponent<InputsManager>().valueLeftStickup;
        valueButtonSouth = sceneInfo.GetComponent<InputsManager>().valueButtonSouth;
        valueLeftTrigger = sceneInfo.GetComponent<InputsManager>().valueLeftTrigger;
        valueRightTrigger = sceneInfo.GetComponent<InputsManager>().valueRightTrigger;
        valueLeftBumper = sceneInfo.GetComponent<InputsManager>().valueLeftBumper;
        valueRightBumper = sceneInfo.GetComponent<InputsManager>().valueRightBumper;
        
    }

    void movement()
    {
        updatecontrols(valueLeftStickright, valueLeftStickleft, valueLeftStickup, valueLeftStickdown);
        float horInput = mvtstick.x * maxvel;
        float verInput = mvtstick.y * maxvel;

        Vector3 camforward = cam.forward;
        Vector3 camright = cam.right;

        camforward.y = 0;
        camright.y = 0;

        Vector3 forwardrelative = camforward * verInput;
        Vector3 rightrelative = camright * horInput;

        Vector3 movedir = Vector3.zero;

        if (horInput != 0 && verInput != 0)
        {
            movedir = forwardrelative / 1.5f + rightrelative / 1.5f;
        }
        else
        {
            movedir = forwardrelative + rightrelative;
        }


        if((collidingx>0 && movedir.x>0) || (collidingx < 0 && movedir.x < 0))
        {
            movedir = new Vector3(0, movedir.y, movedir.z);
        }

        if ((collidingz > 0 && movedir.z > 0) || (collidingz < 0 && movedir.z < 0))
        {
            movedir = new Vector3(movedir.x, movedir.y, 0);
        }

        rb.velocity = new Vector3(movedir.x, rb.velocity.y, movedir.z);

        if (rb.velocity.x != 0 && rb.velocity.z != 0)
        {
            transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    void updatecontrols(float valueright, float valueleft, float valueup, float valuedown)
    {
        if(valueleft ==0 &&  valueright ==0)
        {
            mvtstick.x = 0;
        }
        else if(valueleft ==0 && valueright==1)
        {
            mvtstick.x = 1;
        }
        else if (valueright ==0 && valueleft ==1)
        {
            mvtstick.x = -1;
        }

        if (valuedown == 0 && valueup == 0)
        {
            mvtstick.y = 0;
        }
        else if (valuedown == 0 && valueup == 1)
        {
            mvtstick.y = 1;
        }
        else if (valueup == 0 && valuedown == 1)
        {
            mvtstick.y = -1;
        }
    }

    void checkwalls()
    {
        float range = GetComponent<CapsuleCollider>().radius*1.05f;

        collidingx = 0;
        collidingz = 0;


        for(int i = 1;i<=4;i++)
        {
            if (Physics.Linecast(transform.position + new Vector3(0, i / 2, 0), transform.position + new Vector3(range, i/2, 0)))
            {
                collidingx = 1;
            }
            else if (Physics.Linecast(transform.position + new Vector3(0,  i / 2, 0), transform.position + new Vector3(-range, i/2, 0)))
            {
                collidingx = -1;
            }
            else
            if (Physics.Linecast(transform.position + new Vector3(0,  i / 2, 0), transform.position + new Vector3(0,  i / 2, range)))
            {
                collidingz = 1;
            }
            else if (Physics.Linecast(transform.position + new Vector3(0,  i / 2, 0), transform.position + new Vector3(0, i/2, -range)))
            {
                collidingz = -1;
            }
        }
    }

    

}
