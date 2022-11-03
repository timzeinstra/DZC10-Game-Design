using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
      //input  
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Rotate();

    }

    void FixedUpdate(){
        //Movement
        rb.MovePosition(rb.position + movement*MoveSpeed* Time.fixedDeltaTime);
    }

    void Rotate(){
        Vector3 mousePos = Input.mousePosition;
         mousePos.z = 5.23f;
 
         Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
         mousePos.x = mousePos.x - objectPos.x;
         mousePos.y = mousePos.y - objectPos.y;
 
         float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }   
}
