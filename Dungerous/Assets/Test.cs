using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private AddRoom door; //
    public GameObject enemyType;
    private int numEnemies = 4;

    void Awake()
    {
        door = GetComponent<AddRoom>();
    }

    void spawnEnemies(){
        for (int i = 1; i<=numEnemies; i++){
            int randIndex = Random.Range(0,3);
            Instantiate(enemyType, transform.Find("EnemySpawner").GetChild(randIndex).gameObject.transform.position, Quaternion.identity);
        }
    }
    
    void Start(){
        //StartCoroutine(DoorAction());
        door.isLocked = true;
        door.enemiesSpawned = true;
        spawnEnemies();
    }

    /*private IEnumerator DoorAction(){
        WaitForSeconds wait = new WaitForSeconds(2f);
        for(int i = 0; i <= 10; i++){
            door.isLocked = !door.isLocked;
            yield return wait;
        }
    }*/
}
