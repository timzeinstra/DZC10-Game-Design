using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public AudioSource weaponSound;

    public void Fire(){
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        weaponSound.Play();
        Debug.Log("Shot Bullet");
    }

}