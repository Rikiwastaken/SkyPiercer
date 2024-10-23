//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""9c17cb1c-96df-4be3-9f40-085f26712893"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e38ba259-7277-48b9-a6db-9e7efd7bc1f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""moveup"",
                    ""type"": ""Button"",
                    ""id"": ""579dda7a-eee7-4c48-b6b7-2faf45965f4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""movedown"",
                    ""type"": ""Button"",
                    ""id"": ""21621af0-82aa-49cf-90d3-9dbf203cef14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""moveleft"",
                    ""type"": ""Button"",
                    ""id"": ""89c73d2c-76ce-4419-9c53-55ee4cc098bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""moveright"",
                    ""type"": ""Button"",
                    ""id"": ""4ba6c0bf-7837-48b9-af73-1f90d06ccc03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""camright"",
                    ""type"": ""Button"",
                    ""id"": ""359038dd-88b4-4600-8da2-e3de1d7300e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""camleft"",
                    ""type"": ""Button"",
                    ""id"": ""101d1ecc-5cc9-4e77-998b-aa2cf0cb918b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""camdown"",
                    ""type"": ""Button"",
                    ""id"": ""cfec1ba5-0b4d-4eb6-bc47-94e9dd50039c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""camup"",
                    ""type"": ""Button"",
                    ""id"": ""8b39d65d-ec6c-4e34-8475-14899583df10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""6fb3791e-e849-4d81-ab6c-ca090a183546"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc38f6bd-5cf8-403a-a1c5-3494b759ba6b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b826b62c-8025-4d52-b7d7-e4d61af3de72"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35aacffa-986a-4552-ac71-014de8592bbc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e11e72c-e752-45f1-857f-720431354732"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27d31cfe-bfcf-44e7-afa3-19a185d78cc5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movedown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bdcb41a-8224-4af9-930b-4209da13d36e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movedown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0f2c417-1482-4e8f-83f7-4df7eb92e5ac"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveleft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efa740d4-a94e-4466-af44-34f17731f311"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveleft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2260c05-99c0-4cc7-b9b5-3cbe2dae0397"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveright"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9242667-db46-4e96-944c-32a7e9bc8094"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveright"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af1809d3-991e-4385-b83c-d9ba7af443fb"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a1c5bc9-9837-44ac-a21a-b8128f64894e"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camdown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""737f8169-ea6b-4d0c-bc91-202eaccec2d0"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camleft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a35752c1-00bf-482e-9c6d-07ecd46bf91a"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camright"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65fcb38f-b0cd-426b-809a-27d3c71a919d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f17fa1f9-58f3-4c48-a455-773a14cbda7c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_Jump = m_gameplay.FindAction("Jump", throwIfNotFound: true);
        m_gameplay_moveup = m_gameplay.FindAction("moveup", throwIfNotFound: true);
        m_gameplay_movedown = m_gameplay.FindAction("movedown", throwIfNotFound: true);
        m_gameplay_moveleft = m_gameplay.FindAction("moveleft", throwIfNotFound: true);
        m_gameplay_moveright = m_gameplay.FindAction("moveright", throwIfNotFound: true);
        m_gameplay_camright = m_gameplay.FindAction("camright", throwIfNotFound: true);
        m_gameplay_camleft = m_gameplay.FindAction("camleft", throwIfNotFound: true);
        m_gameplay_camdown = m_gameplay.FindAction("camdown", throwIfNotFound: true);
        m_gameplay_camup = m_gameplay.FindAction("camup", throwIfNotFound: true);
        m_gameplay_Grapple = m_gameplay.FindAction("Grapple", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // gameplay
    private readonly InputActionMap m_gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_gameplay_Jump;
    private readonly InputAction m_gameplay_moveup;
    private readonly InputAction m_gameplay_movedown;
    private readonly InputAction m_gameplay_moveleft;
    private readonly InputAction m_gameplay_moveright;
    private readonly InputAction m_gameplay_camright;
    private readonly InputAction m_gameplay_camleft;
    private readonly InputAction m_gameplay_camdown;
    private readonly InputAction m_gameplay_camup;
    private readonly InputAction m_gameplay_Grapple;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_gameplay_Jump;
        public InputAction @moveup => m_Wrapper.m_gameplay_moveup;
        public InputAction @movedown => m_Wrapper.m_gameplay_movedown;
        public InputAction @moveleft => m_Wrapper.m_gameplay_moveleft;
        public InputAction @moveright => m_Wrapper.m_gameplay_moveright;
        public InputAction @camright => m_Wrapper.m_gameplay_camright;
        public InputAction @camleft => m_Wrapper.m_gameplay_camleft;
        public InputAction @camdown => m_Wrapper.m_gameplay_camdown;
        public InputAction @camup => m_Wrapper.m_gameplay_camup;
        public InputAction @Grapple => m_Wrapper.m_gameplay_Grapple;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @moveup.started += instance.OnMoveup;
            @moveup.performed += instance.OnMoveup;
            @moveup.canceled += instance.OnMoveup;
            @movedown.started += instance.OnMovedown;
            @movedown.performed += instance.OnMovedown;
            @movedown.canceled += instance.OnMovedown;
            @moveleft.started += instance.OnMoveleft;
            @moveleft.performed += instance.OnMoveleft;
            @moveleft.canceled += instance.OnMoveleft;
            @moveright.started += instance.OnMoveright;
            @moveright.performed += instance.OnMoveright;
            @moveright.canceled += instance.OnMoveright;
            @camright.started += instance.OnCamright;
            @camright.performed += instance.OnCamright;
            @camright.canceled += instance.OnCamright;
            @camleft.started += instance.OnCamleft;
            @camleft.performed += instance.OnCamleft;
            @camleft.canceled += instance.OnCamleft;
            @camdown.started += instance.OnCamdown;
            @camdown.performed += instance.OnCamdown;
            @camdown.canceled += instance.OnCamdown;
            @camup.started += instance.OnCamup;
            @camup.performed += instance.OnCamup;
            @camup.canceled += instance.OnCamup;
            @Grapple.started += instance.OnGrapple;
            @Grapple.performed += instance.OnGrapple;
            @Grapple.canceled += instance.OnGrapple;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @moveup.started -= instance.OnMoveup;
            @moveup.performed -= instance.OnMoveup;
            @moveup.canceled -= instance.OnMoveup;
            @movedown.started -= instance.OnMovedown;
            @movedown.performed -= instance.OnMovedown;
            @movedown.canceled -= instance.OnMovedown;
            @moveleft.started -= instance.OnMoveleft;
            @moveleft.performed -= instance.OnMoveleft;
            @moveleft.canceled -= instance.OnMoveleft;
            @moveright.started -= instance.OnMoveright;
            @moveright.performed -= instance.OnMoveright;
            @moveright.canceled -= instance.OnMoveright;
            @camright.started -= instance.OnCamright;
            @camright.performed -= instance.OnCamright;
            @camright.canceled -= instance.OnCamright;
            @camleft.started -= instance.OnCamleft;
            @camleft.performed -= instance.OnCamleft;
            @camleft.canceled -= instance.OnCamleft;
            @camdown.started -= instance.OnCamdown;
            @camdown.performed -= instance.OnCamdown;
            @camdown.canceled -= instance.OnCamdown;
            @camup.started -= instance.OnCamup;
            @camup.performed -= instance.OnCamup;
            @camup.canceled -= instance.OnCamup;
            @Grapple.started -= instance.OnGrapple;
            @Grapple.performed -= instance.OnGrapple;
            @Grapple.canceled -= instance.OnGrapple;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMoveup(InputAction.CallbackContext context);
        void OnMovedown(InputAction.CallbackContext context);
        void OnMoveleft(InputAction.CallbackContext context);
        void OnMoveright(InputAction.CallbackContext context);
        void OnCamright(InputAction.CallbackContext context);
        void OnCamleft(InputAction.CallbackContext context);
        void OnCamdown(InputAction.CallbackContext context);
        void OnCamup(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
    }
}