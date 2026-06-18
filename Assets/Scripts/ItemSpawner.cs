using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance;

    [SerializeField]
    private GameObject[] itemPrefabs;

    [SerializeField]
    private int spawnCount = 20;

    [System.Serializable]
    private class FieldRange
    {
        [SerializeField] private float minX = -100f;
        [SerializeField ]private float maxX = 100f;
        [SerializeField] private float minZ = -100f;
        [SerializeField] private float maxZ = 100f;

        public float MinX => minX ;
        public float MaxX => maxX;
        public float MinZ => minZ;
        public float MaxZ => maxZ;
    }
    [SerializeField]
    private FieldRange fields;

    [SerializeField]
    private float minDistance = 5f;

    [SerializeField]
    private int respawnItemCount = 15;

    private int currentItemCount;

    [SerializeField]
    private float respawnDelay = 5f;

    [SerializeField]
    private Transform spawnPointsParent;

    [SerializeField]
    private Transform itemParent;

    private List<Transform> spawnPoints = new List<Transform>();

    private List<Vector3> spawnedPositions = new List<Vector3>();

    private bool lessItems;

    private int prespawnCount = 0;

    private void Awake()
    {
        Instance = this;
    }

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
        lessItems = currentItemCount + prespawnCount < respawnItemCount;
    }

    private void SpawnItems()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Vector3 position;
            int retryCount = 0;

            do
            {
                float x = Random.Range(fields.MinX, fields.MaxX);
                float z = Random.Range(fields.MinZ, fields.MaxZ);

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
        lessItems = false;
    }

    private void SpawnRandomItem()
    {
        Vector3 position;
        int retryCount = 0;

        do
        {
            float x = Random.Range(fields.MinX, fields.MaxX);
            float z = Random.Range(fields.MinZ, fields.MaxZ);

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
        currentItemCount++;
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
        StartCoroutine(
            RespawnAfterDelay()
        );
    }

    private IEnumerator RespawnAfterDelay()
    {
        prespawnCount++;
        yield return new WaitForSeconds(
            respawnDelay
        );
        SpawnRandomItem();
        prespawnCount--;
    }
}
