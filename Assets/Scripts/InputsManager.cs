using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsManager : MonoBehaviour
{
    [Header("Controls")]
    Controls controls;
    public float valueLeftStickleft;
    public float valueLeftStickright;
    public float valueLeftStickup;
    public float valueLeftStickdown;
    public float valueRightStickleft;
    public float valueRightStickright;
    public float valueRightStickup;
    public float valueRightStickdown;
    public float valueButtonSouth;
    public float valueLeftTrigger;
    public float valueRightTrigger;
    public float valueLeftBumper;
    public float valueRightBumper;

    void Awake()
    {
        controls = new Controls();

        controls.gameplay.moveleft.performed += ctx => valueLeftStickleft = 1;
        controls.gameplay.moveright.performed += ctx => valueLeftStickright = 1;
        controls.gameplay.moveleft.canceled += ctx => valueLeftStickleft = 0;
        controls.gameplay.moveright.canceled += ctx => valueLeftStickright = 0;
        controls.gameplay.movedown.performed += ctx => valueLeftStickdown = 1;
        controls.gameplay.movedown.canceled += ctx => valueLeftStickdown = 0;
        controls.gameplay.moveup.performed += ctx => valueLeftStickup = 1;
        controls.gameplay.moveup.canceled += ctx => valueLeftStickup = 0;
        controls.gameplay.camleft.performed += ctx => valueRightStickleft = 1;
        controls.gameplay.camright.performed += ctx => valueRightStickright = 1;
        controls.gameplay.camleft.canceled += ctx => valueRightStickleft = 0;
        controls.gameplay.camright.canceled += ctx => valueRightStickright = 0;
        controls.gameplay.camdown.performed += ctx => valueRightStickdown = 1;
        controls.gameplay.camdown.canceled += ctx => valueRightStickdown = 0;
        controls.gameplay.camup.performed += ctx => valueRightStickup = 1;
        controls.gameplay.camup.canceled += ctx => valueRightStickup = 0;
        controls.gameplay.ButtonSouth.performed += ctx => valueButtonSouth = 1;
        controls.gameplay.ButtonSouth.canceled += ctx => valueButtonSouth = 0;
        controls.gameplay.LeftTrigger.performed += ctx => valueLeftTrigger = 1;
        controls.gameplay.LeftTrigger.canceled += ctx => valueLeftTrigger = 0;
        controls.gameplay.RightTrigger.performed += ctx => valueRightTrigger = 1;
        controls.gameplay.RightTrigger.canceled += ctx => valueRightTrigger = 0;
        controls.gameplay.LeftBumper.performed += ctx => valueLeftBumper = 1;
        controls.gameplay.LeftBumper.canceled += ctx => valueLeftBumper = 0;
        controls.gameplay.RightBumper.performed += ctx => valueRightBumper = 1;
        controls.gameplay.RightBumper.canceled += ctx => valueRightBumper = 0;


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
