using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip combatMusic;
    public AudioClip deathMusic;
    public AudioClip completeMusic;

    private AudioSource audioSource;
    private bool inFight;
    private bool off;

    // Start is called before the first frame update
    void Start()
    {
        inFight = false;
        off = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!off){
            if (GameObject.FindGameObjectsWithTag("enemy").Length==0){
                if (inFight){
                    inFight = false;
                    audioSource.Stop();
                    audioSource.PlayOneShot(backgroundMusic);
                    audioSource.loop = true;
                }

            } else {
                if (!inFight){
                    inFight = true;
                    audioSource.Stop();
                    audioSource.PlayOneShot(combatMusic);
                    audioSource.loop = true;
                }
            }
        }
    }
    public void PlayDeathMusic(){
        off = true;
        audioSource.Stop();
        audioSource.volume=.5f;
        audioSource.PlayOneShot(deathMusic);
        audioSource.loop = false;
    }

    public void PlayVictoryMusic(){
        off = true;
        audioSource.Stop();
        audioSource.volume=.5f;
        audioSource.PlayOneShot(completeMusic);
        audioSource.loop = false;
    }
}
