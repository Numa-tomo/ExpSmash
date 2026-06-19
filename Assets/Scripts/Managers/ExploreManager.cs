using System.Runtime.CompilerServices;
using UnityEngine;

public class ExploreManager : MonoBehaviour
{
    public static ExploreManager Instance;

    [SerializeField]
    private PlayerSpawner spawner;

    [SerializeField]
    private PlayerController player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitScene();
        // カーソル固定・見えなくする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void InitScene()
    {
        TimeManager.Instance.InitTimer();
        PlayerStatusManager.Instance.InitStatus();
        GameManager.Instance.ResetGameFlags();
        InitPlayerLocation();
    }

    private void InitPlayerLocation()
    {
        Debug.Log("InitPlayerLocation");
        player.SpawnAt(spawner.GetRandomSpawnPoint());
        
    }

    public void ExploreFinish()
    {
        GameManager.Instance.ExplorePartFinish();
    }
}
