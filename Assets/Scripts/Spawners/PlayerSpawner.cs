using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, transform.childCount);

        return transform.GetChild(index);
    }
}
