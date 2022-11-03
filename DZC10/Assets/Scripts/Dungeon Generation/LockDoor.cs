using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public GameObject wallLock;
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

    private void SetRoomLock(bool toLock){
        if (toLock){
            Instantiate(wallLock, transform.position, Quaternion.identity);
        } else {
            Destroy(wallLock);
        }
    }
}