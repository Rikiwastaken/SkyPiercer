using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleSrat : MonoBehaviour
{

    public float rot;

    private Rigidbody rb;

    public Transform cam;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.forward = cam.transform.forward;

        rb.angularVelocity = new Vector3(0, 0, rot);
    }
}
