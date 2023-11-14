using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;

    public GameObject player;
    private Vector2 target;
    private Vector2 direction;

    void Start()
    {
        player = GameObject.Find("Player");

        direction = player.transform.position - transform.position;

        // target = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    void Update()
    {
        //to make bullets follow player just put in player for target
        // transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime); 
        GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed/2500, ForceMode2D.Impulse);


        // if (transform.position.x == target.x && transform.position.y == target.y)
        // {
        //     Destroy(gameObject);
        // }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
        }
    }
}
