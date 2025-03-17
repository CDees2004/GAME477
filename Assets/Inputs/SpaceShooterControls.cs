//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Inputs/SpaceShooterControls.inputactions
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

public partial class @SpaceShooterControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SpaceShooterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SpaceShooterControls"",
    ""maps"": [
        {
            ""name"": ""Standard"",
            ""id"": ""ae3cd4a6-b95f-48d2-a27b-1a179165ab10"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Value"",
                    ""id"": ""72b10a9b-0f30-46dc-94ca-b0a2154a914b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Value"",
                    ""id"": ""38a6bc1a-d86b-4d99-8146-1473c091df9f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Value"",
                    ""id"": ""77d32910-f9a3-47c4-aca9-d69fc39aee82"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Value"",
                    ""id"": ""54690edb-17c9-427c-8367-b24cecbeeddc"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootBullet"",
                    ""type"": ""Button"",
                    ""id"": ""535c3988-355a-4811-bdc4-9d3edc1bb230"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootMissile"",
                    ""type"": ""Button"",
                    ""id"": ""38e11537-517b-4bb0-a54b-1a3a30dc4556"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c3d7e0ec-a688-468e-9657-f0d4415f4a02"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bcc968a-6947-45a6-bfa1-d301a817b2d0"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7473c40d-0f96-4fbf-8fb9-f5a07814fb75"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8469160e-1415-4c53-b151-1ea49775ac1c"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc97ceba-baca-40be-a469-2b89cb603c04"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5bb77a4-994a-40ab-838a-189676c7ce59"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ed1c456-3a2f-4075-9e6b-b540dc686349"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd5515a4-981a-41f3-8930-85d1dcb2761f"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""873b99fb-8b59-482e-9e25-de1aa5a33992"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""939071b7-231d-4066-b666-6698a5dd8320"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""b772e702-1fdb-4645-85e7-c6c6a3036803"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootMissile"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""bfaaef4a-454f-46c8-9a63-1fa546b2625a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootMissile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""5a407d29-6599-48c2-a8aa-746b3db87365"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootMissile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6382ad10-8822-4de0-a69c-8068accc827c"",
                    ""path"": ""<Joystick>/{SecondaryTrigger}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootMissile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Standard
        m_Standard = asset.FindActionMap("Standard", throwIfNotFound: true);
        m_Standard_MoveUp = m_Standard.FindAction("MoveUp", throwIfNotFound: true);
        m_Standard_MoveDown = m_Standard.FindAction("MoveDown", throwIfNotFound: true);
        m_Standard_MoveRight = m_Standard.FindAction("MoveRight", throwIfNotFound: true);
        m_Standard_MoveLeft = m_Standard.FindAction("MoveLeft", throwIfNotFound: true);
        m_Standard_ShootBullet = m_Standard.FindAction("ShootBullet", throwIfNotFound: true);
        m_Standard_ShootMissile = m_Standard.FindAction("ShootMissile", throwIfNotFound: true);
    }

    ~@SpaceShooterControls()
    {
        UnityEngine.Debug.Assert(!m_Standard.enabled, "This will cause a leak and performance issues, SpaceShooterControls.Standard.Disable() has not been called.");
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

    // Standard
    private readonly InputActionMap m_Standard;
    private List<IStandardActions> m_StandardActionsCallbackInterfaces = new List<IStandardActions>();
    private readonly InputAction m_Standard_MoveUp;
    private readonly InputAction m_Standard_MoveDown;
    private readonly InputAction m_Standard_MoveRight;
    private readonly InputAction m_Standard_MoveLeft;
    private readonly InputAction m_Standard_ShootBullet;
    private readonly InputAction m_Standard_ShootMissile;
    public struct StandardActions
    {
        private @SpaceShooterControls m_Wrapper;
        public StandardActions(@SpaceShooterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_Standard_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_Standard_MoveDown;
        public InputAction @MoveRight => m_Wrapper.m_Standard_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_Standard_MoveLeft;
        public InputAction @ShootBullet => m_Wrapper.m_Standard_ShootBullet;
        public InputAction @ShootMissile => m_Wrapper.m_Standard_ShootMissile;
        public InputActionMap Get() { return m_Wrapper.m_Standard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardActions set) { return set.Get(); }
        public void AddCallbacks(IStandardActions instance)
        {
            if (instance == null || m_Wrapper.m_StandardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StandardActionsCallbackInterfaces.Add(instance);
            @MoveUp.started += instance.OnMoveUp;
            @MoveUp.performed += instance.OnMoveUp;
            @MoveUp.canceled += instance.OnMoveUp;
            @MoveDown.started += instance.OnMoveDown;
            @MoveDown.performed += instance.OnMoveDown;
            @MoveDown.canceled += instance.OnMoveDown;
            @MoveRight.started += instance.OnMoveRight;
            @MoveRight.performed += instance.OnMoveRight;
            @MoveRight.canceled += instance.OnMoveRight;
            @MoveLeft.started += instance.OnMoveLeft;
            @MoveLeft.performed += instance.OnMoveLeft;
            @MoveLeft.canceled += instance.OnMoveLeft;
            @ShootBullet.started += instance.OnShootBullet;
            @ShootBullet.performed += instance.OnShootBullet;
            @ShootBullet.canceled += instance.OnShootBullet;
            @ShootMissile.started += instance.OnShootMissile;
            @ShootMissile.performed += instance.OnShootMissile;
            @ShootMissile.canceled += instance.OnShootMissile;
        }

        private void UnregisterCallbacks(IStandardActions instance)
        {
            @MoveUp.started -= instance.OnMoveUp;
            @MoveUp.performed -= instance.OnMoveUp;
            @MoveUp.canceled -= instance.OnMoveUp;
            @MoveDown.started -= instance.OnMoveDown;
            @MoveDown.performed -= instance.OnMoveDown;
            @MoveDown.canceled -= instance.OnMoveDown;
            @MoveRight.started -= instance.OnMoveRight;
            @MoveRight.performed -= instance.OnMoveRight;
            @MoveRight.canceled -= instance.OnMoveRight;
            @MoveLeft.started -= instance.OnMoveLeft;
            @MoveLeft.performed -= instance.OnMoveLeft;
            @MoveLeft.canceled -= instance.OnMoveLeft;
            @ShootBullet.started -= instance.OnShootBullet;
            @ShootBullet.performed -= instance.OnShootBullet;
            @ShootBullet.canceled -= instance.OnShootBullet;
            @ShootMissile.started -= instance.OnShootMissile;
            @ShootMissile.performed -= instance.OnShootMissile;
            @ShootMissile.canceled -= instance.OnShootMissile;
        }

        public void RemoveCallbacks(IStandardActions instance)
        {
            if (m_Wrapper.m_StandardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStandardActions instance)
        {
            foreach (var item in m_Wrapper.m_StandardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StandardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StandardActions @Standard => new StandardActions(this);
    public interface IStandardActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnShootBullet(InputAction.CallbackContext context);
        void OnShootMissile(InputAction.CallbackContext context);
    }
}
