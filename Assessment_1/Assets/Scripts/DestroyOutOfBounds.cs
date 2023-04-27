using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
   // set the limit
    private float lowerBound = -6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detect gameobject that go below -6
        if (transform.position.y < lowerBound)
        {
            //destroy gaobject 
            Destroy(gameObject);
        }
    }
}
