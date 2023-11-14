using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;
    
    public Rigidbody2D rb;
    public float rotationSpeed;

    public GameObject player;

    // public void Fire() 
    // {
        
    //      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //      bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    // }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.M))
        {
            rb.rotation -= rotationSpeed;
        }
        if (Input.GetKey(KeyCode.N))
        {
            rb.rotation += rotationSpeed;
        }
    }

    public void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
    }

}
