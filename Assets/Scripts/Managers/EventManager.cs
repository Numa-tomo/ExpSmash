using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private GameObject goalRoot;

    private int remainingTargets;

    public bool isPlaying {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventSceneInitializer.Instance.InitScene();
        player.canControl = true;
        isPlaying = true;
        goalRoot.SetActive(false);
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
            goalRoot.SetActive(true);
        }
    }

    public void GoalReached()
    {
        EventClear();
    }

    private void EventClear()
    {
        StopTimer();
        GameManager.Instance.EventClear(TimeManager.Instance.countUpTime);
    }

    private void StopTimer()
    {
        isPlaying = false;
    }
}
