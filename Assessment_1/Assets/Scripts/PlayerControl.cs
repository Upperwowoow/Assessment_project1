using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //player jump
    public float jumpSpeed = 8f;
    private float direction = 0f;

    //player rigidbody
    private Rigidbody2D player;

    //on ground 
    
    
    //player rotate
    public float horizontalInput;
    public float turnSpeed = 5f;
    // i have added the variables to fix the problems
    public float Speed = 10f;
    //player gravity 
    public float gravityModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //I have added playerRb = GetComponent<Rigidbody>(); in the void start to fix the problem 
        player = GetComponent<Rigidbody2D>();

        //player gravity/physics
        Physics.gravity *= gravityModifier;
    }

    // I have deleted the  void OnCollisionStay() {isGround = true;} to fix the problem
    // but it doesn't fix the problem that the player fly like rocket. 


    // Update is called once per frame
    void Update()
    {
        //player game play (Jumping)
        // I have change if (Input.GetKeyDown("jump")) to if (Input.GetKeyDown(KeyCode.Space)) 
        // issus fixed 
        if (Input.GetKeyDown(KeyCode.Space))  
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            
        }
        // player control movement (left & righ)
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * Speed, player.velocity.y);
        }

        else if (direction < 0f)
        {
            //I have spell velocity wrong 
            player.velocity = new Vector2(direction * Speed, player.velocity.y);
        }

        else  
        {
            player.velocity = new Vector2(0 * Speed, player.velocity.y);
        }

        // I delete transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //I have delete most of the thing that is player movement 
        //I have also change vector3 to vector2 also Rigidbody3D to Rigidbody2D

        //player rotate 
        horizontalInput = Input.GetAxis("Horizontal");
        //I have fixed the issue by adding , to up - issuse fix
        transform.Rotate(Vector2.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    // on the ground 

    // player collecting Items 
    // I have change(Collision2D other) to (Collide2D other)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bananas"))
        {
            Destroy(other.gameObject);
        }
    }


}

