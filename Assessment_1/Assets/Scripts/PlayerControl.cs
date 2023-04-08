using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float jumpForce = 2;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    public Vector3 jump;
    // i have added the variables to fix the problems 
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //I have added playerRb = GetComponent<Rigidbody>(); in the void start to fix the problem 
        playerRb = GetComponent<Rigidbody>();
    }

    // I have deleted the  void OnCollisionStay() {isGround = true;} to fix the problem
    // but it doesn't fix the problem that the player fly like rocket. 


    // Update is called once per frame
    void Update()
    {
        //player game play (Jumping)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) ;
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
       
        // play control moving
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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

