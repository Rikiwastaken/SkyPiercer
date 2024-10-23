using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playermvt : MonoBehaviour
{

    Controls controls;
    private Rigidbody rb;

    public Transform camera;

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

    float valueleft;
    float valueright;
    float valueup;
    float valuedown;
    float valuejump;
    float grappleinput;

    public int collidingx;
    public int collidingz;

    private float lastvely;

    void Awake()
    {
        controls = new Controls();

        controls.gameplay.moveleft.performed += ctx => valueleft = 1;
        controls.gameplay.moveright.performed += ctx => valueright = 1;
        controls.gameplay.moveleft.canceled += ctx => valueleft = 0;
        controls.gameplay.moveright.canceled += ctx => valueright = 0;
        controls.gameplay.movedown.performed += ctx => valuedown = 1;
        controls.gameplay.movedown.canceled += ctx => valuedown = 0;
        controls.gameplay.moveup.performed += ctx => valueup = 1;
        controls.gameplay.moveup.canceled += ctx => valueup = 0;
        controls.gameplay.Jump.performed += ctx => valuejump = 1;
        controls.gameplay.Jump.canceled += ctx => valuejump = 0;
        controls.gameplay.Grapple.performed += ctx => grappleinput = 1;
        controls.gameplay.Grapple.canceled += ctx => grappleinput = 0;




        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (jumpcnt > 0)
        {
            jumpcnt--;
        }

        checkwalls();

        if(collidingx==0 && collidingz == 0)
        {
            lastvely=rb.velocity.y;
        }


        if (grapkeypressed && grappleinput==0)
        {
            grapkeypressed = false;
        }

        if (grounded)
        {
            GetComponent<Grapplefind>().ReinitGrapples();
        }

        if (GetComponent<Grapplefind>().activegrapple != null && grappleinput==1 && !grapkeypressed && !GetComponent<Grapplefind>().grappling)
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

            if (valuejump != 0 && grounded && jumpcnt == 0)
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

    void movement()
    {
        updatecontrols(valueright, valueleft, valueup, valuedown);
        float horInput = mvtstick.x * maxvel;
        float verInput = mvtstick.y * maxvel;

        Vector3 camforward = camera.forward;
        Vector3 camright = camera.right;

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
        Debug.Log(collidingx+" "+collidingz);
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

    void OnEnable()
    {
        controls.gameplay.Enable();
    }
    void OnDisable()
    {
        controls.gameplay.Disable();
    }

}