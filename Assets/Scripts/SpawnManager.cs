using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerups;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.0f, 9.0f), 7.1f, 0);
            int randomEnemy = (Random.Range(0, 5));
            GameObject newEnemy = Instantiate(_enemyPrefab[randomEnemy], spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(4.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.0f, 9.0f), 7.1f, 0);
            yield return new WaitForSeconds(Random.Range(10.0f, 15.0f));
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerups[randomPowerUp], spawnPosition, Quaternion.identity);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
        StopAllCoroutines();
    }
}
