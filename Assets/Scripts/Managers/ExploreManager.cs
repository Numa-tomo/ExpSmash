using System.Collections;
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

    private IEnumerator Start()
    {
        player.canControl = false;
        InitScene();
        // カーソル固定・見えなくする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yield return new WaitUntil(
            () => CountDownManager.Instance.IsFinished
        );

        player.canControl = true;
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
        player.SpawnAt(spawner.GetRandomSpawnPoint());
    }

    public void ExploreFinish()
    {
        GameManager.Instance.ExplorePartFinish();
    }
}
