using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;

    public GameObject player;

    public int enemyHealth;
    public int collideDamage;

    public float shootingDistance;
    private float timeUntilFire;
    public float fireRate;
    public GameObject bullet;

    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

//MOVEMENT
        Vector2 direction = player.transform.position - transform.position;

        if (Vector2.Distance(this.transform.position, player.transform.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(this.transform.position, player.transform.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, -enemySpeed * Time.deltaTime);
        }

//SHOOTING
        if (Vector2.Distance(this.transform.position, player.transform.position) < shootingDistance)
        {
            if (timeUntilFire <= 0)
            {
                Instantiate(bullet, this.transform.position, Quaternion.identity);
                timeUntilFire = fireRate;
            } 
            else 
            {
                timeUntilFire -= Time.deltaTime;
            }
        }
        
    }

//COLLISION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            enemyHealth -= 1;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
                
    }
}
