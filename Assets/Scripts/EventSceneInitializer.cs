using UnityEngine;

public class EventSceneInitializer : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;

        player.transform.position = spawnPoint.position;

        cc.enabled = true;
    }
}
