using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Player : MonoBehaviour
{

    // upgradable
    public float speed;
    public float fireRate;
    public float maxHealth;
    public float bulletSpeed;
    public static float damage;
    

    public GameObject baseSpawnPoint;
    public GameObject islandSpawnPoint;
    public GameObject yellowSpawnPoint;
    public GameObject pinkSpawnPoint;
    public GameObject redSpawnPoint;
    public GameObject purpleSpawnPoint;
    public GameObject orangeSpawnPoint;


    public Rigidbody2D rb;
    public Barrel barrel;
    public Camera cam; 

    Vector2 movement;
    Vector2 mousePosition;

    private float timeUntilFire;

    public float health = 100;
    public float counter = 1f;
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI yellowGemCountText;
    [SerializeField] TextMeshProUGUI pinkGemCountText;
    [SerializeField] TextMeshProUGUI redGemCountText;
    [SerializeField] TextMeshProUGUI purpleGemCountText;
    [SerializeField] TextMeshProUGUI orangeGemCountText;

    [SerializeField] TextMeshProUGUI yellowBossGemText;
    [SerializeField] TextMeshProUGUI pinkBossGemText;
    [SerializeField] TextMeshProUGUI redBossGemText;
    [SerializeField] TextMeshProUGUI purpleBossGemText;
    [SerializeField] TextMeshProUGUI orangeBossGemText;


    public float yellowGemCount = 0;
    public float pinkGemCount = 0;
    public float redGemCount = 0;
    public float purpleGemCount = 0;
    public float orangeGemCount = 0;

    public float yellowBossGemCount = 0;
    public float pinkBossGemCount = 0;
    public float redBossGemCount = 0;
    public float purpleBossGemCount = 0;
    public float orangeBossGemCount = 0;

        public GameObject GemY;
        public GameObject GemYspot;
        public GameObject GemPi;
        public GameObject GemPispot;
        public GameObject GemR;
        public GameObject GemRspot;
        public GameObject GemP;
        public GameObject GemPspot;
        public GameObject GemO;
        public GameObject GemOspot;

    [SerializeField] UnityEngine.UI.Image yellowBar;
    [SerializeField] UnityEngine.UI.Image pinkBar;
    [SerializeField] UnityEngine.UI.Image redBar;
    [SerializeField] UnityEngine.UI.Image purpleBar;
    [SerializeField] UnityEngine.UI.Image orangeBar;
    [SerializeField] UnityEngine.UI.Image healthBar;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public bool gameOver = false;

    public GameObject gameOverSpawn;
    public float score;

    public GameObject gameOverHolder;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject topLeftUI;



    void Awake()
    {
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        // if (objs.Length > 1)
        // {
        //     Destroy(this.gameObject);
        // }

        // DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        health = maxHealth; 
        timeUntilFire = fireRate;

   
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

        if (timeUntilFire <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
                timeUntilFire = fireRate;
            }
        }
        else 
        {
            timeUntilFire -= Time.deltaTime;
        }
     
        barrel.Rotate();


        Display();
        GemBars();
        Upgrades();
        GameOver();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameOver = true;
        }
    }

    public void addScore(int points)
    {
        score += points;
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "base")
        {
            baseSpawnPoint = GameObject.FindGameObjectWithTag("baseSpawnPoint");
            transform.position = baseSpawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "baseExit")
        {
            islandSpawnPoint = GameObject.FindGameObjectWithTag("islandSpawnPoint");
            transform.position = islandSpawnPoint.transform.position;
        }

        if (collision.gameObject.tag == "yellowEntrance")
        {
            yellowSpawnPoint = GameObject.FindGameObjectWithTag("yellowSpawnPoint");
            transform.position = yellowSpawnPoint.transform.position;  
        }
        if (collision.gameObject.tag == "yellowExit")
        {
            baseSpawnPoint = GameObject.FindGameObjectWithTag("baseSpawnPoint");
            transform.position = baseSpawnPoint.transform.position;
        }


        if (collision.gameObject.tag == "pinkEntrance")
        {
            pinkSpawnPoint = GameObject.FindGameObjectWithTag("pinkSpawnPoint");
            transform.position = pinkSpawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "pinkExit")
        {
            baseSpawnPoint = GameObject.FindGameObjectWithTag("baseSpawnPoint");
            transform.position = baseSpawnPoint.transform.position;
        }

        if (collision.gameObject.tag == "redEntrance")
        {
            redSpawnPoint = GameObject.FindGameObjectWithTag("redSpawnPoint");
            transform.position = redSpawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "redExit")
        {
            baseSpawnPoint = GameObject.FindGameObjectWithTag("baseSpawnPoint");
            transform.position = baseSpawnPoint.transform.position;
        }

        if (collision.gameObject.tag == "purpleEntrance")
        {
            purpleSpawnPoint = GameObject.FindGameObjectWithTag("purpleSpawnPoint");
            transform.position = purpleSpawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "purpleExit")
        {
            baseSpawnPoint = GameObject.FindGameObjectWithTag("baseSpawnPoint");
            transform.position = baseSpawnPoint.transform.position;
        }

        if (collision.gameObject.tag == "orangeEntrance")
        {
            orangeSpawnPoint = GameObject.FindGameObjectWithTag("orangeSpawnPoint");
            transform.position = orangeSpawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "orangeExit")
        {
            baseSpawnPoint = GameObject.FindGameObjectWithTag("baseSpawnPoint");
            transform.position = baseSpawnPoint.transform.position;
        }
        

        if (collision.gameObject.tag == "yellowBullet")
        {
            TakeDamage(5);
        }

        if (collision.gameObject.tag == "pinkBullet")
        {
            TakeDamage(15);
        }

        if (collision.gameObject.tag == "redBullet")
        {
            TakeDamage(10);
        }

        if (collision.gameObject.tag == "purpleBullet")
        {
            TakeDamage(25);
        }

        if (collision.gameObject.tag == "orangeBullet")
        {
            TakeDamage(10);
        }



        if (collision.gameObject.tag == "yellowGem")
        {
            Destroy(collision.gameObject);
            yellowGemCount++;


        }

        if (collision.gameObject.tag == "pinkGem")
        {
            Destroy(collision.gameObject);
            pinkGemCount++;
        }

        if (collision.gameObject.tag == "redGem")
        {
            float currentMaxHealth = maxHealth;
            Destroy(collision.gameObject);
            redGemCount++;
            health += 5;
            // health += ((health / currentMaxHealth) + (health / maxHealth)) / 2;
        }

        if (collision.gameObject.tag == "purpleGem")
        {
            Destroy(collision.gameObject);
            purpleGemCount++;
        }

        if (collision.gameObject.tag == "orangeGem")
        {
            Destroy(collision.gameObject);
            orangeGemCount++;
        }


        if (collision.gameObject.tag == "yellowBossGem")
        {
            Destroy(collision.gameObject);
            yellowBossGemCount = 1;
        }

        if (collision.gameObject.tag == "pinkBossGem")
        {
            Destroy(collision.gameObject);
            pinkBossGemCount = 1;
        }

        if (collision.gameObject.tag == "redBossGem")
        {
            Destroy(collision.gameObject);
            redBossGemCount = 1;
        }

        if (collision.gameObject.tag == "purpleBossGem")
        {
            Destroy(collision.gameObject);
            purpleBossGemCount = 1;
        }

        if (collision.gameObject.tag == "orangeBossGem")
        {
            Destroy(collision.gameObject);
            orangeBossGemCount = 1;
        }

        if (collision.gameObject.tag == "healthPad")
        {
            health = maxHealth;
        }
    }


    public void Display()
    {
        healthText.text = "Health: " + health;

        if (yellowBossGemCount == 1)
        {
            GemY = GameObject.FindGameObjectWithTag("GemY");
            GemYspot = GameObject.FindGameObjectWithTag("GemYspot");
            GemY.transform.position = GemYspot.transform.position;  
        }
        if (pinkBossGemCount == 1)
        {
            GemPi = GameObject.FindGameObjectWithTag("GemPi");
            GemPispot = GameObject.FindGameObjectWithTag("GemPispot");
            GemPi.transform.position = GemPispot.transform.position;  
        }
        if (redBossGemCount == 1)
        {
            GemR = GameObject.FindGameObjectWithTag("GemR");
            GemRspot = GameObject.FindGameObjectWithTag("GemRspot");
            GemR.transform.position = GemRspot.transform.position;  
        }
        if (purpleBossGemCount == 1)
        {
            GemP = GameObject.FindGameObjectWithTag("GemP");
            GemPspot = GameObject.FindGameObjectWithTag("GemPspot");
            GemP.transform.position = GemPspot.transform.position;  
        }
        if (orangeBossGemCount == 1)
        {
            GemO = GameObject.FindGameObjectWithTag("GemO");
            GemOspot = GameObject.FindGameObjectWithTag("GemOspot");
            GemO.transform.position = GemOspot.transform.position;  
        }
    }

    public void GemBars()
    {
        yellowBar.fillAmount = yellowGemCount / 15;
        pinkBar.fillAmount = pinkGemCount / 15;
        redBar.fillAmount = redGemCount / 15;
        purpleBar.fillAmount = purpleGemCount / 15;
        orangeBar.fillAmount = orangeGemCount / 15;

        healthBar.fillAmount = health / maxHealth;

        if (yellowGemCount >= 15)
        {
            yellowGemCount = 15;
        }
        if (pinkGemCount >= 15)
        {
            pinkGemCount = 15;
        }
        if (redGemCount >= 15)
        {
            redGemCount = 15;
        }
        if (purpleGemCount >= 15)
        {
            purpleGemCount = 15;
        }
        if (orangeGemCount >= 15)
        {
            orangeGemCount = 15;
        }

    }

    public void Upgrades()
    {
        speed = 3 + (yellowGemCount / 20);
        fireRate = 1 - (orangeGemCount / 10);
        maxHealth = 100 + (redGemCount * 5);
        bulletSpeed = 5 + (pinkGemCount / 2);
        damage = 1 + (purpleGemCount / 2);
        
    }

    public void Fire() 
    {
         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
         bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }


    void GameOver()
    {
        if (gameOver == true)
        {
            gameOverUI.SetActive(true);
            topLeftUI.SetActive(false);

            gameOverSpawn = GameObject.FindGameObjectWithTag("GameOverSpawn");
            transform.position = gameOverSpawn.transform.position;  

            yellowGemCountText.text = " " + yellowGemCount;
            pinkGemCountText.text = " " + pinkGemCount;
            redGemCountText.text = " " + redGemCount;
            purpleGemCountText.text = " " + purpleGemCount;
            orangeGemCountText.text = " " + orangeGemCount;

            yellowBossGemText.text = " " + yellowBossGemCount;
            pinkBossGemText.text = " " + pinkBossGemCount;
            redBossGemText.text = " " + redBossGemCount;
            purpleBossGemText.text = " " + purpleBossGemCount;
            orangeBossGemText.text = " " + orangeBossGemCount;

            float gemPoints = (yellowGemCount * 10) + (pinkGemCount * 10) + (redGemCount * 10) + (purpleGemCount * 10) + (orangeGemCount * 10);
            float bossPoints = (yellowBossGemCount * 50) + (pinkBossGemCount * 50) + (redBossGemCount * 50) + (purpleBossGemCount * 50) + (orangeBossGemCount * 50);
            score = gemPoints + bossPoints;
            scoreText.text = "Score: " + score;

        }
        
    }

}
