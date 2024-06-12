using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0,7.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        
        if (this.transform.position.y < -5.37f)
        {
            float spawnRandomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(spawnRandomX, 7.5f,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
            
        }  

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }  

    }
}
