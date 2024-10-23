//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""410691a4-0f13-4467-b7d2-1246bfadba7f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3f851405-2092-4e86-a1bc-245b6fb18158"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""3860330f-e99b-47a4-ac80-a05a24f19f15"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""5be35dd2-5dc7-4fac-a5d0-89d6f81784bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelThrow"",
                    ""type"": ""Button"",
                    ""id"": ""d194476f-1830-4482-897c-d47400177685"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TorqueDirection"",
                    ""type"": ""Value"",
                    ""id"": ""68983490-2c8d-4b86-a93f-9f5e107ba6e9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Force"",
                    ""type"": ""Value"",
                    ""id"": ""c96f0957-dcfb-4f19-8212-bc8b01603652"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BackSpin"",
                    ""type"": ""Button"",
                    ""id"": ""b06bca09-c349-4882-8a41-7c7381804e9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ResetPins"",
                    ""type"": ""Button"",
                    ""id"": ""f9c246d2-87d2-40d1-8a46-13a14b42749f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ResetAim"",
                    ""type"": ""Button"",
                    ""id"": ""0106fe2a-d9b6-4ce3-8213-3619b1f04982"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Controls"",
                    ""type"": ""Button"",
                    ""id"": ""33540618-81e7-46b5-a6cc-3b34bb266105"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LoadMainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""a19fba2c-09d8-411a-b25e-f7c4df37f8fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchBall"",
                    ""type"": ""Button"",
                    ""id"": ""96845781-a0a8-4a1d-b7e7-989d17c6f7e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""f64ad173-3f79-4f50-a479-13670ae617e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e1ab1dca-a9b2-406a-af8c-607488e17c5a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d289e745-65c2-4f12-861a-e9e83a2e5968"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e1ddb6f4-2c8b-4987-9882-4cc981864505"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f4c2afdc-fe11-4590-a456-de33ef12a70c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e580338e-9d68-46d0-9820-3bb65a69be84"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""738aefa7-3a4f-4580-a1af-26742d560fb6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3201c503-cd27-4277-af54-ff495cea136c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45cb421d-35b8-437d-9972-0a6d4a71a282"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""641393bb-ae7d-474f-b8d6-c5c4ce47424f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e73e5262-a3db-444c-bf90-f21648167e44"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TorqueDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2347b576-ed39-4e3a-9aa6-7883a7f3357c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TorqueDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""089b2f80-cfa5-4cdd-af1b-45db1dec2ff6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TorqueDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""21a9de2f-ea4f-497b-bc33-caa3ac31f375"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Force"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""36b792de-a4ad-4b3c-a1fa-a8c33ce406b8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Force"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c8a4686-d982-4cd0-bbdd-4976a7c8b1e4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Force"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""15e3ba3a-ee97-4d10-8844-25639f8dbee5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetPins"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b15ed19-63ef-47e4-aad2-ee90e327e75a"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44fe6148-f9cd-49c8-998a-3e3165226995"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackSpin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""558e676b-c4ed-44a7-8f20-7e2f0a68ff8e"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Controls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""813f32d0-7906-4450-9640-d0391635915a"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cd2dafc-3ea1-4633-96f5-0201e816913d"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e9b602-4bcc-4a97-89f6-34bcc3a7087d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""79e55b94-523e-45d7-97fd-102d82f0d6bc"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""982ac475-aa0b-4a73-977a-28d2c50ad114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LoadMainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""3f604afe-0f72-4b4e-909a-19c32c991267"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Controls"",
                    ""type"": ""Button"",
                    ""id"": ""3331b272-2ae9-40ab-a5a6-2cfd2fdafadb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bca89016-90b0-4d3a-b9c3-fc96403ec195"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57eb561a-110c-4239-88bf-e7e78a4c4f2b"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4df77d0a-b4c8-43ce-b8dd-ebfaa735e232"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Controls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_Throw = m_Player.FindAction("Throw", throwIfNotFound: true);
        m_Player_CancelThrow = m_Player.FindAction("CancelThrow", throwIfNotFound: true);
        m_Player_TorqueDirection = m_Player.FindAction("TorqueDirection", throwIfNotFound: true);
        m_Player_Force = m_Player.FindAction("Force", throwIfNotFound: true);
        m_Player_BackSpin = m_Player.FindAction("BackSpin", throwIfNotFound: true);
        m_Player_ResetPins = m_Player.FindAction("ResetPins", throwIfNotFound: true);
        m_Player_ResetAim = m_Player.FindAction("ResetAim", throwIfNotFound: true);
        m_Player_Controls = m_Player.FindAction("Controls", throwIfNotFound: true);
        m_Player_LoadMainMenu = m_Player.FindAction("LoadMainMenu", throwIfNotFound: true);
        m_Player_SwitchBall = m_Player.FindAction("SwitchBall", throwIfNotFound: true);
        m_Player_Quit = m_Player.FindAction("Quit", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Quit = m_UI.FindAction("Quit", throwIfNotFound: true);
        m_UI_LoadMainMenu = m_UI.FindAction("LoadMainMenu", throwIfNotFound: true);
        m_UI_Controls = m_UI.FindAction("Controls", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_Throw;
    private readonly InputAction m_Player_CancelThrow;
    private readonly InputAction m_Player_TorqueDirection;
    private readonly InputAction m_Player_Force;
    private readonly InputAction m_Player_BackSpin;
    private readonly InputAction m_Player_ResetPins;
    private readonly InputAction m_Player_ResetAim;
    private readonly InputAction m_Player_Controls;
    private readonly InputAction m_Player_LoadMainMenu;
    private readonly InputAction m_Player_SwitchBall;
    private readonly InputAction m_Player_Quit;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputAction @CancelThrow => m_Wrapper.m_Player_CancelThrow;
        public InputAction @TorqueDirection => m_Wrapper.m_Player_TorqueDirection;
        public InputAction @Force => m_Wrapper.m_Player_Force;
        public InputAction @BackSpin => m_Wrapper.m_Player_BackSpin;
        public InputAction @ResetPins => m_Wrapper.m_Player_ResetPins;
        public InputAction @ResetAim => m_Wrapper.m_Player_ResetAim;
        public InputAction @Controls => m_Wrapper.m_Player_Controls;
        public InputAction @LoadMainMenu => m_Wrapper.m_Player_LoadMainMenu;
        public InputAction @SwitchBall => m_Wrapper.m_Player_SwitchBall;
        public InputAction @Quit => m_Wrapper.m_Player_Quit;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
            @CancelThrow.started += instance.OnCancelThrow;
            @CancelThrow.performed += instance.OnCancelThrow;
            @CancelThrow.canceled += instance.OnCancelThrow;
            @TorqueDirection.started += instance.OnTorqueDirection;
            @TorqueDirection.performed += instance.OnTorqueDirection;
            @TorqueDirection.canceled += instance.OnTorqueDirection;
            @Force.started += instance.OnForce;
            @Force.performed += instance.OnForce;
            @Force.canceled += instance.OnForce;
            @BackSpin.started += instance.OnBackSpin;
            @BackSpin.performed += instance.OnBackSpin;
            @BackSpin.canceled += instance.OnBackSpin;
            @ResetPins.started += instance.OnResetPins;
            @ResetPins.performed += instance.OnResetPins;
            @ResetPins.canceled += instance.OnResetPins;
            @ResetAim.started += instance.OnResetAim;
            @ResetAim.performed += instance.OnResetAim;
            @ResetAim.canceled += instance.OnResetAim;
            @Controls.started += instance.OnControls;
            @Controls.performed += instance.OnControls;
            @Controls.canceled += instance.OnControls;
            @LoadMainMenu.started += instance.OnLoadMainMenu;
            @LoadMainMenu.performed += instance.OnLoadMainMenu;
            @LoadMainMenu.canceled += instance.OnLoadMainMenu;
            @SwitchBall.started += instance.OnSwitchBall;
            @SwitchBall.performed += instance.OnSwitchBall;
            @SwitchBall.canceled += instance.OnSwitchBall;
            @Quit.started += instance.OnQuit;
            @Quit.performed += instance.OnQuit;
            @Quit.canceled += instance.OnQuit;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
            @CancelThrow.started -= instance.OnCancelThrow;
            @CancelThrow.performed -= instance.OnCancelThrow;
            @CancelThrow.canceled -= instance.OnCancelThrow;
            @TorqueDirection.started -= instance.OnTorqueDirection;
            @TorqueDirection.performed -= instance.OnTorqueDirection;
            @TorqueDirection.canceled -= instance.OnTorqueDirection;
            @Force.started -= instance.OnForce;
            @Force.performed -= instance.OnForce;
            @Force.canceled -= instance.OnForce;
            @BackSpin.started -= instance.OnBackSpin;
            @BackSpin.performed -= instance.OnBackSpin;
            @BackSpin.canceled -= instance.OnBackSpin;
            @ResetPins.started -= instance.OnResetPins;
            @ResetPins.performed -= instance.OnResetPins;
            @ResetPins.canceled -= instance.OnResetPins;
            @ResetAim.started -= instance.OnResetAim;
            @ResetAim.performed -= instance.OnResetAim;
            @ResetAim.canceled -= instance.OnResetAim;
            @Controls.started -= instance.OnControls;
            @Controls.performed -= instance.OnControls;
            @Controls.canceled -= instance.OnControls;
            @LoadMainMenu.started -= instance.OnLoadMainMenu;
            @LoadMainMenu.performed -= instance.OnLoadMainMenu;
            @LoadMainMenu.canceled -= instance.OnLoadMainMenu;
            @SwitchBall.started -= instance.OnSwitchBall;
            @SwitchBall.performed -= instance.OnSwitchBall;
            @SwitchBall.canceled -= instance.OnSwitchBall;
            @Quit.started -= instance.OnQuit;
            @Quit.performed -= instance.OnQuit;
            @Quit.canceled -= instance.OnQuit;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Quit;
    private readonly InputAction m_UI_LoadMainMenu;
    private readonly InputAction m_UI_Controls;
    public struct UIActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_UI_Quit;
        public InputAction @LoadMainMenu => m_Wrapper.m_UI_LoadMainMenu;
        public InputAction @Controls => m_Wrapper.m_UI_Controls;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Quit.started += instance.OnQuit;
            @Quit.performed += instance.OnQuit;
            @Quit.canceled += instance.OnQuit;
            @LoadMainMenu.started += instance.OnLoadMainMenu;
            @LoadMainMenu.performed += instance.OnLoadMainMenu;
            @LoadMainMenu.canceled += instance.OnLoadMainMenu;
            @Controls.started += instance.OnControls;
            @Controls.performed += instance.OnControls;
            @Controls.canceled += instance.OnControls;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Quit.started -= instance.OnQuit;
            @Quit.performed -= instance.OnQuit;
            @Quit.canceled -= instance.OnQuit;
            @LoadMainMenu.started -= instance.OnLoadMainMenu;
            @LoadMainMenu.performed -= instance.OnLoadMainMenu;
            @LoadMainMenu.canceled -= instance.OnLoadMainMenu;
            @Controls.started -= instance.OnControls;
            @Controls.performed -= instance.OnControls;
            @Controls.canceled -= instance.OnControls;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnCancelThrow(InputAction.CallbackContext context);
        void OnTorqueDirection(InputAction.CallbackContext context);
        void OnForce(InputAction.CallbackContext context);
        void OnBackSpin(InputAction.CallbackContext context);
        void OnResetPins(InputAction.CallbackContext context);
        void OnResetAim(InputAction.CallbackContext context);
        void OnControls(InputAction.CallbackContext context);
        void OnLoadMainMenu(InputAction.CallbackContext context);
        void OnSwitchBall(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnLoadMainMenu(InputAction.CallbackContext context);
        void OnControls(InputAction.CallbackContext context);
    }
}
