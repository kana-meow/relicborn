using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    private InputManager input;
    private CharacterController controller;

    [Header("Settings")]
    [SerializeField] private float speed = 10;

    [SerializeField] private float gravity = 9.81f;

    private Vector3 velocity;

    private void Awake() {
        input = InputManager.Instance;
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        if (input == null) return;

        Vector2 moveInput = input.MoveInput;
        Vector3 moveVector = new(moveInput.x, 0, moveInput.y);

        controller.Move(moveVector * speed * Time.deltaTime);

        // apply gravity
        if (!controller.isGrounded) {
            velocity.y -= gravity * Time.deltaTime;
        } else {
            velocity.y = -2f; // keep grounded
        }

        controller.Move(velocity * Time.deltaTime);
    }
}