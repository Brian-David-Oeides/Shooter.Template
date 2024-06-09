using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    // Update is called once per frame
    void Update()
    {
        FireLaser();
    }

    void FireLaser()
    {
    this.transform.Translate(_speed * Time.deltaTime * Vector3.up);
        
        if(this.transform.position.y > 8f)
        {
        	Destroy(this.gameObject);
        }
    }
}
