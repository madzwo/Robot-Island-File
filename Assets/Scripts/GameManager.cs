using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // int health = 100;
    // int score = 0;
    
    // [SerializeField] TextMeshProUGUI scoreText;
    // [SerializeField] TextMeshProUGUI healthText;
    
    // public static GameManager instance;

    // public GameObject player;

    private void Awake() 
    {
        // instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        // IncreaseScore(1);
        // DecreaseHealth(1);
        
    }

    public void IncreaseScore(int amount)
    {
        // score += amount;
        // scoreText.text = "Score: " + score;
    }

    public void DecreaseHealth(int amount)
    {
        // health -= amount;
        // healthText.text = "Health: " + health;

    }
}
