using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text message;
    public Music music;
    public void Setup(bool killedBoss){
        Debug.Log("Game Over Screen Called");
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        gameObject.SetActive(true);
        if (killedBoss){
            message.text = "Floor complete";
            music.PlayVictoryMusic();
        }
    }
}
