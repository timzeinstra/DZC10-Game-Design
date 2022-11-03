using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;

    public Rigidbody2D player;
    public int health;
    Vector2 moveDirection;
    Vector2 mousePosition;
    public int blinkdistance;
    public TMP_Text healthBox;
    public GameOver gameOver;
    public Music music;

    public float dashSpeed;
    public float dashLength = .5f; 
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    
    void Start(){
        health =3;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(Input.GetMouseButtonDown(0)){
            weapon.Fire();
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
    if (Input.GetKeyDown(KeyCode.Space))
     {
         if(dashCoolCounter <= 0 && dashCounter<= 0){
            moveSpeed = dashSpeed;
            dashCounter = dashLength;
         }
     }
     if(dashCounter > 0){
        dashCounter -= Time.deltaTime;
        if(dashCounter <= 0 ){
            moveSpeed = 5f;
            dashCoolCounter = dashCooldown;

        }
     }
    if(dashCoolCounter >0){
        dashCoolCounter -= Time.deltaTime;
    }
    }
    
    private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x*moveSpeed,moveDirection.y*moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y,aimDirection.x)*Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void OnCollisionEnter2D(Collision2D collision){
   
    if (collision.gameObject.tag == "enemy")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
    
            health = health-1;
        }


    if (collision.gameObject.tag == "Bullet")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
    
            health = health-1;
        }
    if (collision.gameObject.tag == "BossBullet"){
        health=0;
    }
    if(health == 0){
    gameOver.Setup(false);
    music.PlayDeathMusic();
    //Destroy(gameObject);
    // run end scene
    
    }
    //GameObject.FindGameObjectWithTag("Health").GetComponent<TMP>().text = "Health: "+health+"/3";
    healthBox.text = "Health: "+health+"/3";
    }

     public void DashAbility(float x, float y) // so here I tried to do dragon(from Katana Zaro) dash but I believe that for attack it would be the same
 {
     rb.velocity = Vector2.zero;
     moveDirection = new Vector2(mousePosition.x, mousePosition.y); // remember that mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     transform.position = moveDirection; // the only thing to change is this cause you need to move for an equal ammount of units each time you attack
 }
}