using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float crouchSpeed = 1.25f;
    public float sprintSpeed = 5f; // Скорость при беге
    public float gravity = 1f;
    public float jumpHeight = 0.01f;
    public float crouchHeight = 1f;
    public float standingHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching;
    private bool isSprinting;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Обработка приседания
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            StartCrouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) 
        {
            StopCrouch();
        }

        // Обработка ускорения (Shift)
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching) // Ускорение не работает при приседании
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        // Определяем текущую скорость
        float currentSpeed = isCrouching ? crouchSpeed : (isSprinting ? sprintSpeed : moveSpeed);

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump") && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void StartCrouch()
    {
        isCrouching = true;
        controller.height = crouchHeight;
        moveSpeed = crouchSpeed;
    }

    private void StopCrouch()
    {
        isCrouching = false;
        controller.height = standingHeight;
        moveSpeed = 2.5f; // Стандартная скорость
    }
}
