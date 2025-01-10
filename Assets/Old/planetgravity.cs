using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetgravity : MonoBehaviour
{
    public float gravitystr;

    public ArrayList attractedlist =new ArrayList();

    public float autoOrientSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(!attractedlist.Contains(other.transform))
        {
            attractedlist.Add(other.transform);
            Debug.Log(other.transform.name + " added;");
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void FixedUpdate()
    {
        foreach(Transform attracted in attractedlist)
        {
            Vector3 grav = GetGravVector(attracted);
            if(attracted.GetComponent<Rigidbody>() != null)
            {
                attracted.GetComponent<Rigidbody>().AddForce(grav * gravitystr * attracted.GetComponent<Rigidbody>().mass*Time.deltaTime);
                RotateToCenter(attracted);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (attractedlist.Contains(other.transform))
        {

            attractedlist.Remove(other.transform);
            Debug.Log(other.transform.name + " removed;");
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private Vector3 GetGravVector(Transform target)
    {
        Vector3 grav = transform.position - target.localPosition;
        grav = Vector3.Normalize(grav);

        return grav;
    }

    private void RotateToCenter(Transform target)
    {

        Vector3 down = (transform.position - target.localPosition).normalized;

        Quaternion orientation = Quaternion.FromToRotation(-target.transform.up, down) * target.rotation;
        target.rotation = Quaternion.Slerp(target.rotation, orientation, autoOrientSpeed * Time.deltaTime);
    }

}
