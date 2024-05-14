using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    private CharacterController controller;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        //check to see if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
        
        //reset velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //get inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //setting the movement vector
        Vector3 move = transform.right * x + transform.forward * z;
        
        //update player
        controller.Move(move * speed * Time.deltaTime);
        
        //checks if player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //gives player gravity
        velocity.y += gravity * Time.deltaTime;
        
        //actually jumping
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            //future use
        }
        else
        {
            isMoving = false;
            //also future use
        }

        lastPosition = gameObject.transform.position;
    }
}
