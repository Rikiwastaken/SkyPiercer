using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1920, 1080,false);
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
