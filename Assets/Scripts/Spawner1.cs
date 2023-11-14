using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnIncreaseRate;
    private float timeUntilSpawn;

    [SerializeField] GameObject spawnPosition;
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Awake()
    {
        timeUntilSpawn = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 6)
        {
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn <= 0)
            {
                Instantiate(enemyPrefab, spawnPosition.gameObject.transform.position, Quaternion.identity);
                spawnRate -= spawnIncreaseRate;
                SetTimeUntilSpawn();
            }
        }
        
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = spawnRate;
    }
    
}
