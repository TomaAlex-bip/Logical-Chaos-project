using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public static SpawnerScript Instance { get; private set; }

    public int[] enemyTypes = new int[4];


    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private float minSeconds;
    [SerializeField] private float maxSeconds;

    private List<Transform> spawnPoints = new List<Transform>();


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        Init();

    }

    private void Init()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Start()
    {
        foreach(Transform child in transform)
        {
            spawnPoints.Add(child);
        }

    }



    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            
            int enemyType = Random.Range(0, enemies.Count);
            int rng = Random.Range(0, 100);
            if(rng == 69)
            {
                enemyType = 3;
            }


            Instantiate(enemies[enemyType], 
                        spawnPoint.transform.position, 
                        Quaternion.identity);
            
            if(enemyType < 3)
            {
                enemyTypes[enemyType]++;
            }
        }

    }
}
