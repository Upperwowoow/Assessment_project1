using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    public float speed = 4f;
    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this how the background move down by using speed 
        transform.Translate(translation: Vector3.down * speed * Time.deltaTime);

        // the backgorund will replace when the number drop down to the i have put in
        if (transform.position.y < -3.216296f)
        {
            transform.position = StartPosition;
        }
        
    }
}
