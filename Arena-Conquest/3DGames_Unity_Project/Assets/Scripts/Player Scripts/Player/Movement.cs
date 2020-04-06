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
    public LayerMask groundDamageMask;
    public LayerMask PlatformMask;
    public Transform groundCheckTransform;
    public bool isGrounded;

    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    event Death OnDeath;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        GetComponent<Health>().OnDeath += OnDeath;

    }

    private void Update()
    {

        Vector3 moveDirection;
        //float horizontal = Input.GetAxis("Horizontal");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = transform.right * horizontal;
        moveDirection.Normalize();
        controller.Move(moveDirection * Time.deltaTime * horizontalSpeed);

        moveDirection = transform.forward * vertical;
        moveDirection.Normalize();
        controller.Move(moveDirection * Time.deltaTime * verticalSpeed);


        // checking for ground 
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckDis, groundCheckMask);
        if (Physics.CheckSphere(groundCheckTransform.position, groundCheckDis, groundDamageMask))
        {
            GetComponent<Health>().TakeDamage(0.01f);
        }

        //if (Physics.CheckSphere(groundCheckTransform.position, groundCheckDis, PlatformMask))
        //{
        //    //this.transform.parent = GameObject.FindGameObjectWithTag("Platform").transform;
        //    this.transform.position = GameObject.FindGameObjectWithTag("Platform").transform.position + this.transform.position;
        //    Debug.Log("On Platform");

        //}

        if (isGrounded && velocity.y < 0)
            velocity.y = -jumpHeight;

        velocity.y += gravitySpeed * Time.deltaTime;

        if (gravitySpeed > 0)
            gravitySpeed *= -1;

        // jump controll 
        if (isGrounded && Input.GetButton("Jump"))
        {
            //Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravitySpeed);
        }


        controller.Move(velocity * Time.deltaTime);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckDis);

    }




}
