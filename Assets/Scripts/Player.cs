using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    public GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    [SerializeField]
    private float _canFire = -1f;

    void Start()
    {
        this.transform.position = new Vector3(0,0,0);
    }

    void Update()
    {
        CalculateMovement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) 
        {
            CalculateFire();
        }
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        transform.Translate(_speed * Time.deltaTime * direction); 

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

    void CalculateFire()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        //{
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, this.transform.position + new Vector3(0,0.9f,0), Quaternion.identity);
        //}
    }
}
