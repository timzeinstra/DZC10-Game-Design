using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    public void RestartDungeon() {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoMainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
