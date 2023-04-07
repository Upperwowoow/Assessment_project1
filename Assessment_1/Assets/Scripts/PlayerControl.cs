using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float jumpForce = 10;
    private Rigidbody playerRb;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //player game play (Jumping)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround);
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
}
