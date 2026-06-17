using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance;

    [SerializeField]
    private GameObject[] itemPrefabs;

    [SerializeField]
    private int spawnCount = 20;

    [SerializeField]
    private float minX = -100f;

    [SerializeField]
    private float maxX = 100f;

    [SerializeField]
    private float minZ = -100f;

    [SerializeField]
    private float maxZ = 100f;

    [SerializeField]
    private float minDistance = 5f;

    [SerializeField]
    private int targetItemCount = 20;

    private int currentItemCount;

    [SerializeField]
    private Transform spawnPointsParent;

    [SerializeField]
    private Transform itemParent;

    private List<Transform> spawnPoints = new List<Transform>();

    private List<Vector3> spawnedPositions = new List<Vector3>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Transform child in spawnPointsParent)
        {
            spawnPoints.Add(child);
        }

        SpawnItems();
    }

    void Update()
    {
        if(currentItemCount < targetItemCount)
        {
            SpawnRandomItem();
        }
    }

    private void SpawnItems()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Vector3 position;
            int retryCount = 0;

            do
            {
                float x = Random.Range(minX, maxX);
                float z = Random.Range(minZ, maxZ);

                position = new Vector3(x, 0.5f, z);

                retryCount++;
            }while(
                IsTooClose(position)
                && retryCount < 50
            );

            spawnedPositions.Add(position);

            int itemIndex = Random.Range(0, itemPrefabs.Length);

            Instantiate(
                itemPrefabs[itemIndex],
                position,
                Quaternion.identity,
                itemParent
            );
        }
        currentItemCount = spawnCount;
    }

    private void SpawnRandomItem()
    {
        Vector3 position;
        int retryCount = 0;

        do
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);

            position = new Vector3(x, 0.5f, z);

            retryCount++;
        }while(
            IsTooClose(position)
            && retryCount < 50
        );

        spawnedPositions.Add(position);

        int itemIndex = Random.Range(0, itemPrefabs.Length);

        Instantiate(
            itemPrefabs[itemIndex],
            position,
            Quaternion.identity,
            itemParent
        );
    }

    private bool IsTooClose(Vector3 position)
    {
        foreach(Vector3 spawnedPos in spawnedPositions)
        {
            if(
                Vector3.Distance(
                    position,
                    spawnedPos
                ) < minDistance
            )
            { return true; }
        }

        return false;
    }

    public void ItemCollected()
    {
        currentItemCount--;
    }
}
