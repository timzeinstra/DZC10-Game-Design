using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private int numEnemies = 3;
    private bool active = false;
    private int enemiesRemaining;
    public GameObject enemyType;
    public GameObject boss;
    private Transform room;
    private GameObject gameOver;
    void Start(){
        room = this.transform.parent;
        gameOver = FindInActiveObjectByName("GameOver");
    }

    GameObject FindInActiveObjectByName(string name)
{
    Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    for (int i = 0; i < objs.Length; i++)
    {
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].name == name)
            {
                return objs[i].gameObject;
            }
        }
    }
    return null;
}

    void spawnEnemies(){
        room.GetComponent<AddRoom>().isLocked = true;
        active = true;
        if (room.GetComponent<AddRoom>().isFinalRoom){
            int randIndex = Random.Range(0,3);
            Instantiate(boss, transform.parent.Find("EnemySpawner").GetChild(randIndex).gameObject.transform.position, Quaternion.identity);
        } else {
            numEnemies = Random.Range(1,4);
            for (int i = 0; i<=numEnemies-1; i++){
                Instantiate(enemyType, transform.parent.Find("EnemySpawner").GetChild(i).gameObject.transform.position, Quaternion.identity);
            }
        }
    }

    void Update(){
        if (active){
            /*enemiesRemaining = 0;
            for (int i = 0; i < transform.root.childCount; ++i){
                Debug.Log("For loop: " + transform.root.GetChild(i));
                enemiesRemaining++;
            }*/
            if (GameObject.FindGameObjectsWithTag("enemy").Length==0){
                active = false;
                room.GetComponent<AddRoom>().isLocked = false;
                if (room.GetComponent<AddRoom>().isFinalRoom) {
                    gameOver.GetComponent<GameOver>().Setup(true);//
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")) {
            Debug.Log("Player detected!");
            if (!room.GetComponent<AddRoom>().enemiesSpawned) {
                room.GetComponent<AddRoom>().enemiesSpawned = true;
                spawnEnemies();
            }
        }
    }
}