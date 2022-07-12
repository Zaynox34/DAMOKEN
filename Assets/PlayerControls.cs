// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""War"",
            ""id"": ""0f2597a3-dbd1-4165-b337-12af10b28cb9"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9bb6f171-2014-4546-8986-b663b91aa237"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slash0"",
                    ""type"": ""Button"",
                    ""id"": ""e52a5759-a02d-42c5-b578-74fb5f6c6032"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5474fba4-6dea-48c8-8d2d-04af02b4115f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c820c1a3-9406-42e7-84ff-5b7e0bc91c6d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4403fe40-acec-4de9-9b8b-da773675d42a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0ac5be10-ee3c-4c74-9799-66457d2cbfae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2528323e-6f87-4bd9-b771-ac6f24a38aab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f3c4e030-3552-467e-a0b8-5076ca748df7"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slash0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // War
        m_War = asset.FindActionMap("War", throwIfNotFound: true);
        m_War_Walk = m_War.FindAction("Walk", throwIfNotFound: true);
        m_War_Slash0 = m_War.FindAction("Slash0", throwIfNotFound: true);
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

    // War
    private readonly InputActionMap m_War;
    private IWarActions m_WarActionsCallbackInterface;
    private readonly InputAction m_War_Walk;
    private readonly InputAction m_War_Slash0;
    public struct WarActions
    {
        private @PlayerControls m_Wrapper;
        public WarActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_War_Walk;
        public InputAction @Slash0 => m_Wrapper.m_War_Slash0;
        public InputActionMap Get() { return m_Wrapper.m_War; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WarActions set) { return set.Get(); }
        public void SetCallbacks(IWarActions instance)
        {
            if (m_Wrapper.m_WarActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_WarActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_WarActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_WarActionsCallbackInterface.OnWalk;
                @Slash0.started -= m_Wrapper.m_WarActionsCallbackInterface.OnSlash0;
                @Slash0.performed -= m_Wrapper.m_WarActionsCallbackInterface.OnSlash0;
                @Slash0.canceled -= m_Wrapper.m_WarActionsCallbackInterface.OnSlash0;
            }
            m_Wrapper.m_WarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Slash0.started += instance.OnSlash0;
                @Slash0.performed += instance.OnSlash0;
                @Slash0.canceled += instance.OnSlash0;
            }
        }
    }
    public WarActions @War => new WarActions(this);
    public interface IWarActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnSlash0(InputAction.CallbackContext context);
    }
}
