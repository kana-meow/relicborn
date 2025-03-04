using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager> {
    private InputSystem_Actions input;

    private Vector2 moveInput;
    public Vector2 MoveInput => moveInput;

    private Vector2 mousePos;
    public Vector2 MousePos => mousePos;

    private Vector2 lookTowards;
    public Vector2 LookTowards => lookTowards;

    public delegate void ActionEvent();

    public event ActionEvent OnInteract;

    public event ActionEvent OnAttack;

    public ControlScheme currentControlScheme;

    public enum ControlScheme {
        KeyboardAndMouse,
        Gamepad
    }

    protected override void Awake() {
        base.Awake();

        input = new();

        // movement
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        // look
        input.Player.MousePosition.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        input.Player.Look.performed += ctx => lookTowards = ctx.ReadValue<Vector2>();

        // actions
        // input.Player.Interact.performed += ctx => OnInteract?.Invoke();

        foreach (var map in input.asset.actionMaps) {
            foreach (var action in map.actions) {
                action.performed += ctx => UpdateControlScheme(ctx);
            }
        }
    }

    private void UpdateControlScheme(InputAction.CallbackContext ctx) {
        if (ctx.control.device is Keyboard || ctx.control.device is Mouse) {
            currentControlScheme = ControlScheme.KeyboardAndMouse;
        } else if (ctx.control.device is Gamepad) {
            currentControlScheme = ControlScheme.Gamepad;
        }
    }

    private void OnEnable() => input.Enable();

    private void OnDisable() => input.Disable();
}