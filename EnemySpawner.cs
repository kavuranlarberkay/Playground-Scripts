using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class EnemySpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCounter;
    public GameObject enemyPrefab;
    public int enemiesPerWave = 5;
    public float rectWidth = 10f;
    public float rectHeight = 10f;
    public Vector2 spawnCenter = Vector2.zero;
    public float spawnInterval = 1f;
    public float spawnDelay = 5f;
    public bool isWaveActive = false;
    private int currentWave = 0;
    private int enemiesSpawned = 0;
    private Coroutine spawnCoroutine;
    public GameObject winUI;
    public GameObject waveCounterObject;

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
        waveCounter.text = "Wave:" + currentWave;

        if (isWaveActive && enemiesSpawned >= enemiesPerWave)
        {
            // wait for all enemies to be killed
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                // end wave and start next wave after delay
                EndWave();
                StartCoroutine(StartNextWaveAfterDelay());
            }
        }
    }

    private void StartNextWave()
    {

        if (currentWave == 5 )
        {
            isWaveActive = false;
            winUI.SetActive(true);
            Time.timeScale = 0f;
            waveCounterObject.SetActive(false);
            return;  
        }
        
        
        currentWave++;
        enemiesPerWave += 5;
        enemiesSpawned = 0;
        isWaveActive = true;
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator StartNextWaveAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        StartNextWave();
    }

    private void EndWave()
    {
        isWaveActive = false;
        StopCoroutine(spawnCoroutine);
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (isWaveActive)
        {
            // spawn enemies until the target number is reached
            while (enemiesSpawned < enemiesPerWave)
            {
                Vector2 spawnPosition = spawnCenter + new Vector2(Random.Range(-rectWidth / 2f, rectWidth / 2f), Random.Range(-rectHeight / 2f, rectHeight / 2f));
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemiesSpawned++;
                yield return new WaitForSeconds(spawnInterval);
            }

            // wait for all enemies to be killed
            while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                yield return null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(rectWidth, rectHeight, 0));
    }
}




