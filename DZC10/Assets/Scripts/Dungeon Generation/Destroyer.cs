using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	private string[] whitelist = {"Player","enemy","Bullet","BossBullet", "DiedScreen", "MainCamera"};

	void OnTriggerEnter2D(Collider2D other){
		bool destroy = true;
		for (int i=0; i<whitelist.Length; i++){
			if(other.gameObject.tag == whitelist[i]){
				destroy = false;
			}
		}
		if (destroy){
			Debug.Log("Time for Destruction");
			Destroy(other.gameObject);
		}
	}
}
