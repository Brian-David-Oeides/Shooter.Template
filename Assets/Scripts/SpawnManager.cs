using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;  //this is the game object we want to spawn
    [SerializeField]
    private GameObject _enemyContainer;
    // create a variable that turns off the while loop that is a bool
    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //spawn objects every 5 sec
        //need coroutine of type IEnumerator using yield
        //while loop - an infinite loop as long as a conditionis true
    }

    IEnumerator SpawnRoutine()
    {   
        while(_stopSpawning == false)
        {   
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f); 
        }
        
        //while loop (important to create inside of coroutines b/c it is infinte loop)
            //instantiate enemy prefab
            // yield wait for 5 seconds
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
