using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab1;
    public GameObject circlePrefab2;
    public GameObject circleHoldPrefab;
    public float breathInCount = 5.0f;
    public float breathHoldCount = 5.0f;
    public float breathOutCount = 5.0f;

    private bool isSpawningPrefab1 = true;
    private bool isSpawningPrefabHold = false;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (isSpawningPrefab1)
            {
                Vector3 spawnPosition = new Vector3(-2.1f, 2.0f, 0f);
                Instantiate(circlePrefab1, spawnPosition, Quaternion.identity);
                isSpawningPrefab1 = false;
                isSpawningPrefabHold = true;
                yield return new WaitForSeconds(breathInCount);
            }
            else if(isSpawningPrefabHold)
            {
                Vector3 spawnPosition = new Vector3(0,5,0);
                Instantiate(circleHoldPrefab, spawnPosition, Quaternion.identity);
                isSpawningPrefabHold = false;
                yield return new WaitForSeconds(breathHoldCount);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(2.2f, 2.0f, 0f);
                Instantiate(circlePrefab2, spawnPosition, Quaternion.identity);
                isSpawningPrefab1 = true;
                yield return new WaitForSeconds(breathOutCount);
            }
        }
    }
}