using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //player jump
    public float jumpForce = 2;

    //player rigidbody
    private Rigidbody playerRb;

    //on ground 
    public bool isOnGround = true;
    
    //player rotate
    public float horizontalInput;
    public float turnSpeed = 5f;
    //player movement
    private float forwardInput;
    // i have added the variables to fix the problems 
    public float speed = 10f;
    //player gravity 
    public float gravityModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //I have added playerRb = GetComponent<Rigidbody>(); in the void start to fix the problem 
        playerRb = GetComponent<Rigidbody>();

        //player gravity/physics
        Physics.gravity *= gravityModifier;
    }

    // I have deleted the  void OnCollisionStay() {isGround = true;} to fix the problem
    // but it doesn't fix the problem that the player fly like rocket. 


    // Update is called once per frame
    void Update()
    {
        //player game play (Jumping)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround);
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        // player control movement (left & righ)
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //player rotate 
        horizontalInput = Input.GetAxis("Horizontal");
        //I have fixed the issue by adding , to up - issuse fix
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    // on the ground 
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}

