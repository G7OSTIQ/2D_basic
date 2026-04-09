using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
[RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer))]// what this does will auto add a rigibody in 2D

public class player_controls : MonoBehaviour
{
    [Header("controls")]
    public float speed = 5f;
    public float jump_force = 3f;

    [Header("Checks")]

    public Transform groundCheck;


    private Rigidbody2D myrigitbody2D;
    private SpriteRenderer mespriterender;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         myrigitbody2D = GetComponent<Rigidbody2D>();
        mespriterender = GetComponent<SpriteRenderer>();
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
        if (value.isPressed && isGrouned())
        {
            myrigitbody2D.linearVelocityY = jump_force;
        }


    }

    //will check if ground is collided
    private bool isGrouned()
    {
        Vector2 size = new Vector2(0.2f, 0.1f);
        return Physics2D.OverlapBox(groundCheck.position,size, 0);
    }

        
}
