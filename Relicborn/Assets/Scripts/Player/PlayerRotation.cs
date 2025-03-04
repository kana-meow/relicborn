using System;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    private InputManager input;
    private Camera mainCamera;

    private void Awake() {
        input = InputManager.Instance;
        mainCamera = Camera.main;
    }

    private void Update() {
        if (input.currentControlScheme == InputManager.ControlScheme.KeyboardAndMouse) {
            RotateWithMouse();
        } else {
            RotateWithGamepad();
        }
    }

    private void RotateWithGamepad() {
        if (input.LookTowards.sqrMagnitude > 0.01f) {
            Vector3 direction = new Vector3(input.LookTowards.x, 0, input.LookTowards.y).normalized;
            transform.forward = direction;
        }
    }

    private void RotateWithMouse() {
        Ray ray = mainCamera.ScreenPointToRay(input.MousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter)) {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = (hitPoint - transform.position).normalized;
            direction.y = 0;
            transform.forward = direction;
        }
    }
}