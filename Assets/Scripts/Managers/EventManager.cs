using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [SerializeField]
    private PlayerController player;

    private int remainingTargets;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventSceneInitializer.Instance.InitScene();
        player.canControl = true;
    }

    public void RegisterTarget()
    {
        remainingTargets++;
    }

    public void TargetDestroyed()
    {
        remainingTargets--;

        if(remainingTargets <= 0)
        {
            EventClear();
        }
    }

    public void EventClear()
    {
        GameManager.Instance.EventClear();
    }
}
