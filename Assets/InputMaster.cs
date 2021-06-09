// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""4596dd22-36a5-4ec5-b025-b4eec550197f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""cea4cf32-a29c-4673-a551-c06c713b4d53"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftArm"",
                    ""type"": ""Button"",
                    ""id"": ""fb65e4dc-2e46-4da2-8ae5-48970f12eac4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightArm"",
                    ""type"": ""Button"",
                    ""id"": ""e13e2fe0-d306-47ad-bfee-479d017fd49d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""7a4483f8-16d7-4062-8d33-1ae41c9898ac"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LanzarIzq"",
                    ""type"": ""Button"",
                    ""id"": ""c3a80876-b0a4-4203-bdff-1637463adcb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LanzarDer"",
                    ""type"": ""Button"",
                    ""id"": ""fcf95153-8d3e-4ca7-a27e-719d8edddafb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""56bb168c-4c29-4332-b253-55168402d6a2"",
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
                    ""id"": ""632c0594-351e-4970-8c5e-91f7c1d41bce"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(max=1)"",
                    ""groups"": ""Oculus"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8f92931f-e3b1-46e9-8af8-06d875673598"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1)"",
                    ""groups"": ""Oculus"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ba50d6e7-bedd-4ec5-b859-2edd920e56db"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1)"",
                    ""groups"": ""Oculus"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2fab56dd-f669-459e-b95a-e7bf175d6ee2"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(max=1)"",
                    ""groups"": ""Oculus"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a7e61a26-ef7f-4aa7-b847-6f5b73e81720"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""LeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""754a219c-300a-4c0b-a66d-cc212904a124"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "" keyboard and mouse"",
                    ""action"": ""LeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b84757a3-2653-4015-b13f-75ac59c621b6"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""RightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""492a7648-6941-44c8-9213-ced6705f9996"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "" keyboard and mouse"",
                    ""action"": ""RightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d50875a7-5282-4cdf-9510-b4e644440648"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a0464e9-09db-4106-b677-ec08da959efd"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "" keyboard and mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c45a2d52-f944-4f1e-b013-d74c1d0a9ef3"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "" keyboard and mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a394d0e-50cb-4e8e-b632-ab6f746faab0"",
                    ""path"": ""<Mouse>/radius/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "" keyboard and mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""41517144-3bda-4a3e-a439-1b554d0fe87b"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "" keyboard and mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fad9f824-441a-45e8-af0a-f0c8f15d3931"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9eb97076-d346-408b-be5b-1716df18a86c"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""72cb1fd6-9ea7-4147-9b95-6ef45000e9b8"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a700d51-c864-4ee9-885f-e61f6824f4f4"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""30d2097a-9491-4e66-8666-9a7ae0a21ad5"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""78dcb2a2-428d-4499-a9fa-34cbfb8a690a"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Oculus"",
                    ""action"": ""LanzarIzq"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97aaf8e6-1ef7-42b4-b8bc-f192864a7b8d"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Oculus; keyboard and mouse"",
                    ""action"": ""LanzarDer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9dc9c3d-3ae1-4fa9-b7ba-6df59f9e1505"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LanzarDer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59e41219-5f6d-4e30-b5da-9e0bcb3df9d2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LanzarIzq"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""controller"",
            ""bindingGroup"": ""controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": "" keyboard and mouse"",
            ""bindingGroup"": "" keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Oculus"",
            ""bindingGroup"": ""Oculus"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_LeftArm = m_Player.FindAction("LeftArm", throwIfNotFound: true);
        m_Player_RightArm = m_Player.FindAction("RightArm", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_LanzarIzq = m_Player.FindAction("LanzarIzq", throwIfNotFound: true);
        m_Player_LanzarDer = m_Player.FindAction("LanzarDer", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_LeftArm;
    private readonly InputAction m_Player_RightArm;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_LanzarIzq;
    private readonly InputAction m_Player_LanzarDer;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @LeftArm => m_Wrapper.m_Player_LeftArm;
        public InputAction @RightArm => m_Wrapper.m_Player_RightArm;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @LanzarIzq => m_Wrapper.m_Player_LanzarIzq;
        public InputAction @LanzarDer => m_Wrapper.m_Player_LanzarDer;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @LeftArm.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftArm;
                @LeftArm.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftArm;
                @LeftArm.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftArm;
                @RightArm.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightArm;
                @RightArm.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightArm;
                @RightArm.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightArm;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @LanzarIzq.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLanzarIzq;
                @LanzarIzq.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLanzarIzq;
                @LanzarIzq.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLanzarIzq;
                @LanzarDer.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLanzarDer;
                @LanzarDer.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLanzarDer;
                @LanzarDer.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLanzarDer;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LeftArm.started += instance.OnLeftArm;
                @LeftArm.performed += instance.OnLeftArm;
                @LeftArm.canceled += instance.OnLeftArm;
                @RightArm.started += instance.OnRightArm;
                @RightArm.performed += instance.OnRightArm;
                @RightArm.canceled += instance.OnRightArm;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @LanzarIzq.started += instance.OnLanzarIzq;
                @LanzarIzq.performed += instance.OnLanzarIzq;
                @LanzarIzq.canceled += instance.OnLanzarIzq;
                @LanzarDer.started += instance.OnLanzarDer;
                @LanzarDer.performed += instance.OnLanzarDer;
                @LanzarDer.canceled += instance.OnLanzarDer;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_controllerSchemeIndex = -1;
    public InputControlScheme controllerScheme
    {
        get
        {
            if (m_controllerSchemeIndex == -1) m_controllerSchemeIndex = asset.FindControlSchemeIndex("controller");
            return asset.controlSchemes[m_controllerSchemeIndex];
        }
    }
    private int m_keyboardandmouseSchemeIndex = -1;
    public InputControlScheme keyboardandmouseScheme
    {
        get
        {
            if (m_keyboardandmouseSchemeIndex == -1) m_keyboardandmouseSchemeIndex = asset.FindControlSchemeIndex(" keyboard and mouse");
            return asset.controlSchemes[m_keyboardandmouseSchemeIndex];
        }
    }
    private int m_OculusSchemeIndex = -1;
    public InputControlScheme OculusScheme
    {
        get
        {
            if (m_OculusSchemeIndex == -1) m_OculusSchemeIndex = asset.FindControlSchemeIndex("Oculus");
            return asset.controlSchemes[m_OculusSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLeftArm(InputAction.CallbackContext context);
        void OnRightArm(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnLanzarIzq(InputAction.CallbackContext context);
        void OnLanzarDer(InputAction.CallbackContext context);
    }
}
