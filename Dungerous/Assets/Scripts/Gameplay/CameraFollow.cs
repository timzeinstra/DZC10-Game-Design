
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void LateUpdate(){
        if (target){
        Vector3 desiredPosition = target.position+ offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = smoothedPosition;
        }
    }
}
