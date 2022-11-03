using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public Weapon weapon;
    public bool AllowedToFire;
    private float timer = 0.0f;
    public float fireRate = 1;
    public float rotationModifier;
    public float rotationSpeed;
    void Start()
    {
       health = maxHealth; 
       target = GameObject.Find("Player").transform;
    }
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(target){
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation,q,Time.deltaTime * rotationSpeed);
            
            rb.rotation = angle;
            moveDirection = direction;
        }
        
        
        if(AllowedToFire){
            weapon.Fire();
            AllowedToFire = false;
        }
        
        pauseFire();
    }
    void FixedUpdate(){
        if(target){
            rb.velocity = new Vector2(moveDirection.x,moveDirection.y)*moveSpeed;
        }
    }
    void pauseFire(){
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            AllowedToFire = true;

            // Remove the recorded firerate;
            timer = timer - fireRate;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
    
    
    
    

    if (collision.gameObject.tag == "Bullet")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
    
            health = health-1;
        }
    if(health == 0){
    Destroy(gameObject);
    
    
    }
    }
    
    
}
