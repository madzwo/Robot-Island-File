using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Barrel barrel;
    public Camera cam; 

    Vector2 movement;
    Vector2 mousePosition;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
        }

        transform.position = position;


        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Fire();
        }
        
        barrel.Rotate();

    }
}
