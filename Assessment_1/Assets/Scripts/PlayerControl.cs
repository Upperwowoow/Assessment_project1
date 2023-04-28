using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //player jump/movement 
    public float jumpSpeed = 8f;
    private float direction = 0f;

    //player barrier 
    public float xRange = 9;

    //player rigidbody
    private Rigidbody2D player;

    //on ground 
    public bool isOnGround = true;

    //gameover 
    public bool gameOver;
    

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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
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


        // this code is for the player barrier 
        // if it max range the player will not be able to move
       
        //left
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //right 
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    // on the ground 

    // player collecting Items 
    // I have change(Collision2D other) to (Collide2D other)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //this code will tell the player the gameobject name
        if (other.gameObject.CompareTag("Bananas"))
        {
            //if the player touches the gameobject that have the tag name whatere i put in 
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Apple"))
        {
            
            Destroy(other.gameObject);

        }

        else if (other.gameObject.CompareTag("Cherries"))
        {

            Destroy(other.gameObject);

        }

        else if (other.gameObject.CompareTag("Kiwi"))
        {

            Destroy(other.gameObject);

        }
        // I move the Trap code to public class from
        // the private void OnTriggerEnter2D(Collider2D other)
        // issue fixed 


    }
    //Trap
    private void OnCollisionEnter2D(Collision2D other)
    {
        //I deleted the else issue fix
        //this coding did the same thing the items code 
        //but there is a gave over if the player touch it
        if (other.gameObject.CompareTag("Trap"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }

        else if (other.gameObject.CompareTag("Saw"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }

        else if (other.gameObject.CompareTag("END"))
        {
            gameOver = true;
            Debug.Log("GAME WIN!");
        }

        // first I check the code and look at the code above so 
        // I replace the collison with the other issue fix 
        else if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
        }
    }

}

