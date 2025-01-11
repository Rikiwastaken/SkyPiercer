using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class Grapplefind : MonoBehaviour
{
    GameObject[] grapplepoints;

    public GameObject activegrapple=null;

    public float range;

    public RaycastHit RC;

    public bool grappling;

    public Transform hand;

    void Awake()
    {
        grapplepoints = GameObject.FindGameObjectsWithTag("grapple");
        
    }

    void FixedUpdate()
    {
        if(!grappling)
        {
            activegrapple = Grapplefinder(hand.transform.position, range);
        }
        

    }

    GameObject Grapplefinder(Vector3 start, float range)
    {
        float dist;
        GameObject closestgrapple = null;
        foreach (GameObject grapplepoint in grapplepoints)
        {
            HideGrapple(grapplepoint);

            if (!Physics.Linecast(start,grapplepoint.transform.position-(grapplepoint.transform.position - start) *0.1f))
            {
                dist = Vector3.Distance(start, grapplepoint.transform.position);
                if (dist <= range && !grapplepoint.GetComponent<GrapplePoint>().alreadyused)
                {
                    if (closestgrapple != null)
                    {
                        if (dist <= Vector3.Distance(start, closestgrapple.transform.position))
                        {
                            closestgrapple = grapplepoint;
                        }
                    }
                    else
                    {
                        closestgrapple = grapplepoint;
                    }
                }
            }
        }
        ShowGrapple(closestgrapple);
        return closestgrapple;
    }

    public void ReinitGrapples()
    {
        foreach (GameObject grapplepoint in grapplepoints)
        { 
            if(grapplepoint.GetComponent<GrapplePoint>().alreadyused)
            {
                grapplepoint.GetComponent<GrapplePoint>().alreadyused = false;
            }
        }
    }

    void ShowGrapple(GameObject grapple)
    {
        if(grapple != null)
        {
            SpriteRenderer SR = grapple.GetComponentInChildren<SpriteRenderer>();
            if (SR.color.a != 1)
            {
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
            }
        }
    }

    void HideGrapple(GameObject grapple)
    {
        if(grapple != null)
        {
            SpriteRenderer SR = grapple.GetComponentInChildren<SpriteRenderer>();
            if (SR.color.a != 0f)
            {
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0f);
            }
        }
    }
    void OnDrawGizmos()
    {
        if(activegrapple != null)
        {
            Gizmos.DrawLine(hand.transform.position, activegrapple.transform.position);
        }
    }

}
