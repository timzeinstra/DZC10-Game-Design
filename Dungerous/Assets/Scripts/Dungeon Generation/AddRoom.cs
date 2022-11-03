using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	private RoomTemplates templates;
	public GameObject wallLock;
    private GameObject wallLockObject;
    private bool _isLocked = false;
    public bool isLocked {
        get {return _isLocked;}
        set {
            if (_isLocked != value) {
                _isLocked = value;
                SetRoomLock(value);
            }
        }
    }
    public bool enemiesSpawned = false;
    public bool isFinalRoom = false;
    /*public bool enemiesSpawned {
        get {return _enemiesSpawned;}
        set {
            if (_enemiesSpawned != value) {
                _enemiesSpawned = value;
            }
        }
    }*/

	void Start(){

		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
	}

    private void SetRoomLock(bool toLock){
        if (toLock){
            wallLockObject = Instantiate(wallLock, transform.position, Quaternion.identity);
        } else {
            Destroy(wallLockObject);
        }
    }
}
