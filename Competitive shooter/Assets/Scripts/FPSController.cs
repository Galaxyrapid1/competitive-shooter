using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Camera")]
    public Transform playerRoot;
    public Transform playerCam;

    public float cameraSensitivity;

    private float rotX;
    private float rotY;

    [Header("Movement")] 
    CharacterController controller;

    public float speed;
    public float jumpHeight;
    public Transform feet;
    private bool isGrounded;

    [Header("Input")] 
    public InputAction move;

    public InputAction jump;
    public InputAction mouseX;
    public InputAction mouseY;

    private void OnEnable() {
        move.Enable();
        jump.Enable();
        mouseX.Enable();
        mouseY.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        mouseX.Disable();
        mouseY.Disable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 mouseInput = new Vector2(mouseX.ReadValue<float>() * cameraSensitivity,
            mouseY.ReadValue<float>() * cameraSensitivity);
        rotX -= mouseInput.y;
        rotX = Mathf.Clamp(rotX, -90, 90);
        rotY -= mouseInput.x;

        playerRoot.rotation = Quaternion.Euler(0f, rotY, 0f);
        playerCam.localRotation = Quaternion.Euler(rotX, 0f, 0f);
    }
}
