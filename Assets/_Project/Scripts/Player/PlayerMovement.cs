using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public float groundDistance = 0.3f;
    public float jumpHeight = 3f;
    public float maxYVelocity = -10f;
    public float speed = 12, gravityStrenght = 9.81f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        gravityStrenght = -gravityStrenght;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityStrenght);
        }

        if (velocity.y > maxYVelocity)
        {
            velocity.y += gravityStrenght * Time.deltaTime;
        }
        else if (velocity.y < maxYVelocity)
        {
            velocity.y = maxYVelocity;
        }


        controller.Move(velocity * Time.deltaTime);


    }
}
