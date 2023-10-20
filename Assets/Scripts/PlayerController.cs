using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction movementInput;
    private bool isAccelerating = false;
    private float maxWalkSpeed = 7f;
    private Rigidbody playerRigidBody;
    private Vector3 walkVelocity;
    private Vector2 cameraAngles;
    private Vector3 movementDirection;

    private void OnEnable()
    {
        movementInput.Enable();
    }
    private void OnDisable()
    {
        movementInput.Disable();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRigidBody = GetComponent<Rigidbody>();
        movementInput.performed += MovementInput_performed;
        movementInput.canceled += MovementInput_canceled;
    }
    private void MovementInput_performed(InputAction.CallbackContext callback)
    {
        isAccelerating = true;
    }
    private void MovementInput_canceled(InputAction.CallbackContext callback)
    {
        isAccelerating = false;
    }
    private void HandleLook()
    {
        cameraAngles += Mouse.current.delta.ReadValue() / 10f;
        ClampRotation();
        transform.rotation = Quaternion.Euler(new(0f, cameraAngles.x, 0f));
        Camera.main.transform.localRotation = Quaternion.Euler(new(-cameraAngles.y, 0f, 0f));
    }
    private void ClampRotation()
    {
        cameraAngles.y = Mathf.Clamp(cameraAngles.y, -90f, 90f);
    }
    private void HandleMovement()
    {
         movementDirection = transform.forward * movementInput.ReadValue<Vector2>().y + transform.right * movementInput.ReadValue<Vector2>().x;
    }
    private void HandleAcceleration()
    {
        if (!isAccelerating) return;
        walkVelocity += movementDirection * 50f * Time.deltaTime;
        walkVelocity = Vector3.ClampMagnitude(walkVelocity, maxWalkSpeed);
    }
    private void HandleDeceleration()
    {
        if (isAccelerating) return;

        walkVelocity -= new Vector3(walkVelocity.x, 0f, walkVelocity.z).normalized * 10f * Time.deltaTime;
        if (Mathf.Abs(walkVelocity.x) < 0.1f)
        {
            walkVelocity.x = 0f;
        }
        if (Mathf.Abs(walkVelocity.z) < 0.1f)
        {
            walkVelocity.z = 0f;
        }
    }

    private void ApplyVelocity()
    {
        playerRigidBody.velocity = walkVelocity;
    }

    void Update()
    {
        HandleLook();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleAcceleration();
        HandleDeceleration();
        ApplyVelocity();
    }
}
