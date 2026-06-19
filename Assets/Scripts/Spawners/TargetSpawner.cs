using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private Transform spawnPointParent;

    [SerializeField]
    private int spawnCount = 5;

    private List<Transform> spawnPoints = new List<Transform>();

    private List<Vector3> spawnedPositions = new List<Vector3>();

    private void Awake()
    {
        spawnCount = GameSettingsManager.Instance.targetCount;
    }

    void Start()
    {
        foreach(Transform child in spawnPointParent)
        {
            spawnPoints.Add(child);
        }
        SpawnTargets();
    }

    private void SpawnTargets()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Vector3 position;
            int retryCount = 0;
            do
            {
                int index = Random.Range(
                    0,
                    spawnPoints.Count
                );

                position = spawnPoints[index].position;
                retryCount++;
            }while(
                spawnedPositions.Contains(position)
                && retryCount < 50
            );

            spawnedPositions.Add(position);

            Instantiate(
                targetPrefab,
                position,
                Quaternion.Euler(90f, 0f, 0f)
            );

            EventManager.Instance.RegisterTarget();
        }
    }
}
