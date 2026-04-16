using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
[RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer),typeof(Animator))]// what this does will auto add a rigibody in 2D

public class player_controls : MonoBehaviour
{
    [Header("controls")]
    public float speed = 5f;
    public float jump_force = 3f;

    [Header("Checks")]

    public Transform groundCheck;

    private int jumpleft = 2;


    private Rigidbody2D myrigitbody2D;
    private SpriteRenderer mespriterender;
    private Animator myanimator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myrigitbody2D = GetComponent<Rigidbody2D>();
        mespriterender = GetComponent<SpriteRenderer>();
        myanimator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {



        float velocityX = Mathf.Abs(myrigitbody2D.linearVelocityX);
    
        myanimator.SetFloat("Velocity", velocityX);
        myanimator.SetFloat("Falling_Velocity", myrigitbody2D.linearVelocityY);
        myanimator.SetBool("Jumping", isGrouned());
        myanimator.SetInteger("Jump_Left", jumpleft);
       
    }

    private void OnMove(InputValue value)
    {

        Vector2 input = value.Get<Vector2>();
        if (input.x != 0)// if the input is x it will do something else it does not
        {
            mespriterender.flipX = input.x < 0;//This will flip the character 
        }
        
        myrigitbody2D.linearVelocityX = input.x * speed;
        
       
    }

    private void OnJump(InputValue value)
    {
        if (isGrouned())
        {
            jumpleft = 2;
        }

        if (value.isPressed && (isGrouned() || jumpleft > 0))
        {
            myrigitbody2D.linearVelocityY = jump_force;
            jumpleft--;
        }


    }



    //will check if ground is collided
    private bool isGrouned()
    {
        Vector2 size = new Vector2(0.2f, 0.1f);
        return Physics2D.OverlapBox(groundCheck.position,size, 0);
    }

        
}
