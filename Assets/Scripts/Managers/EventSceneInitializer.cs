using UnityEngine;

public class EventSceneInitializer : MonoBehaviour
{
    public static EventSceneInitializer Instance;
    [SerializeField]
    private Transform spawnPoint;

    void Start()
    {
        Instance = this;
    }

    public void InitScene()
    {
        InitPlayerLocation();
    }

    private void InitPlayerLocation()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;

        player.transform.position = spawnPoint.position;

        cc.enabled = true;
    }
}
