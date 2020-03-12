using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float gravitySpeed = 10f;
    public float jumpHeight = 8f;
    public float groundCheckDis;
    public LayerMask groundCheckMask;
    public Transform groundCheckTransform;

    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {

        bool isGrounded;
        Vector3 moveDirection;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = transform.right * horizontal;
        moveDirection.Normalize();
        controller.Move(moveDirection * Time.deltaTime * horizontalSpeed);

        moveDirection = transform.forward * vertical;
        moveDirection.Normalize();
        controller.Move(moveDirection * Time.deltaTime * verticalSpeed);

        if (gravitySpeed > 0)
            gravitySpeed *= -1;
        // checking for ground 
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckDis, groundCheckMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -jumpHeight;

        // jump controll 
        if (isGrounded && Input.GetButton("Jump"))
        {
            //Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravitySpeed);
        }

        velocity.y += gravitySpeed * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
