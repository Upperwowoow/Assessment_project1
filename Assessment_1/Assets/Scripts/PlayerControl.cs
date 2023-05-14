using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Audio
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    

    // Start is called before the first frame update
    void Start()
    {
        //I have added playerRb = GetComponent<Rigidbody>(); in the void start to fix the problem 
        player = GetComponent<Rigidbody2D>();

        //player gravity/physics
        Physics.gravity *= gravityModifier;

        //Audio
        playerAudio = GetComponent<AudioSource>();
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
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        

        // player control movement (left & righ)
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * Speed, player.velocity.y);
        }

        else if (direction < 0f)
        {
            //I have spell velocity wrong iusse fix 
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
            //if the player go to the left it's will stop you at -9 
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //right 
        if (transform.position.x > xRange)
        {
            //if the player go to the right it's will stop you at +9
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
        //but there is a debug.log gave over if the player touch it
        if (other.gameObject.CompareTag("Trap"))
        {
            //it will tell the game that when the player touches the comparetag the gameOver = true
            gameOver = true;
            //if the player touches the comparetag (Trap) it will praint out GameOver in the console
            Debug.Log("Game Over!");
            // when the player touches the comparetag (Trap) it will switch to the GameOver scene
            SceneManager.LoadScene("GameOver");
            
        }

        else if (other.gameObject.CompareTag("Saw"))
        {
            //it will tell the game that when the player touches the comparetag the gameOver = true
            gameOver = true;
            //if the player touches the comparetag (saw) it will praint out GameOver in the console
            Debug.Log("Game Over!");
            // when the player touches the comparetag (saw) it will switch to the GameOver scene
            SceneManager.LoadScene("GameOver");
            
        }

        else if (other.gameObject.CompareTag("END"))
        {
            gameOver = true;
            Debug.Log("GAME WIN!");
            SceneManager.LoadScene("GameWin");
        }

        // first I check the code and look at the code above so 
        // I replace the collison with the other issue fix 
        else if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
        }
    }

}

