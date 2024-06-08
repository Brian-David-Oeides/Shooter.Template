using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    void Start()
    {
        this.transform.position = new Vector3(0,0,0);
    }

    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        transform.Translate(speed * Time.deltaTime * direction); 

        /*if (transform.position.y >= 2) 
        { 
            this.transform.position = new Vector3(transform.position.x,2,0);
        }
        else if(transform.position.y <= -3.8f)
        {
            this.transform.position = new Vector3(transform.position.x, -3.8f,0);
        }*/
        //Clamp substitution for if statement
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-3.8f,2),0);

        if(this.transform.position.x >= 11.23f)
        {
        	this.transform.position = new Vector3(-11.23f, transform.position.y, 0);
        }
        else if(transform.position.x <= -11.23f)
        {
        	this.transform.position = new Vector3(11.23f, transform.position.y, 0);
        }
    }
}
