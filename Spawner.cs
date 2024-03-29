using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private int totalWaves = 5;
    [SerializeField] private float spawnDelay = 1.0f;
    [SerializeField] private float initialSpawnDelay = 3.0f;
    [SerializeField] private int minSpawnEnemy = 4;
    [SerializeField] private int maxSpawnEnemy = 5;
    [SerializeField] private int incrementSpawnEnemy = 10;
    [SerializeField] private int[] enemyPos;
    private GameManager gmp;


    private int currentWave = 1;
    private bool spawning = false;

    void Start()
    {
        GameManager.Instance.maxSpawnWawes = totalWaves;
        StartCoroutine(SpawnWaves());
        for (int i = 0; i < enemyPos.Length - 1; i++)
        {
            enemyPos[i + 1] += enemyPos[i];
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialSpawnDelay);

        while (currentWave <= totalWaves)
        {
            GameManager.Instance.waweControl = true;
            SpawnWave();
            yield return new WaitUntil(() => AllEnemiesDead()); // Bekle, tüm düþmanlar ölünceye kadar
            yield return new WaitForSeconds(spawnDelay);
            currentWave++;

        }
        GameManager.Instance.succesfull= true;
        
    }

   
    private void SpawnWave()
    {
        spawning = true;
        GameObject enemyPrefab = null;
        int numberOfEnemies = Random.Range(minSpawnEnemy, maxSpawnEnemy);
        minSpawnEnemy += incrementSpawnEnemy;
        maxSpawnEnemy += incrementSpawnEnemy;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            int totalWeight = enemyPos[enemyPos.Length - 1];
            int enemyType = Random.Range(1, totalWeight - 1);
            UnityEngine.Debug.Log("random sayi:" + enemyType);
            if (enemyType <= enemyPos[0])
            {
                UnityEngine.Debug.Log("1egirdi");
                enemyPrefab = enemyPrefabs[0];
            }
            else if (enemyPos[0]< enemyType&& enemyType <= enemyPos[1])
            {
                UnityEngine.Debug.Log("2egirdi");
                UnityEngine.Debug.Log("enemyPos[0]"+ enemyPos[0]);
                UnityEngine.Debug.Log("enemyPos[1]" + enemyPos[1]);
                enemyPrefab = enemyPrefabs[1];
            }
            else if (enemyPos[1] < enemyType && enemyType <= enemyPos[2])
            {
                UnityEngine.Debug.Log("3egirdi");
                enemyPrefab = enemyPrefabs[2];

            }
            else if (enemyPos[2] < enemyType && enemyType <= enemyPos[3])
            {UnityEngine.Debug.Log("4egirdi");
                enemyPrefab = enemyPrefabs[3];

            }
            else if (enemyPos[3] < enemyType && enemyType <= enemyPos[4])
            {UnityEngine.Debug.Log("5egirdi");
                enemyPrefab = enemyPrefabs[4];

            }
            UnityEngine.Debug.Log("random sayi2:" + enemyType);
            Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity);
            Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity);
            Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity);

        }
    }

    private bool AllEnemiesDead()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                return false; // En az bir düþman yaþýyorsa false döndür
            }
        }

        if (spawning)
        {
            spawning = false;
        }

        return true; // Tüm düþmanlar öldüyse true döndür
    }
}