using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private GameObject goalRoot;

    private int remainingTargets;

    private float eventTime;

    private bool isPlaying;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventSceneInitializer.Instance.InitScene();
        player.canControl = true;
        eventTime = 0f;
        isPlaying = true;
        goalRoot.SetActive(false);
    }

    private void Update()
    {
        if (isPlaying)
        {
            eventTime += Time.deltaTime;
        }
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

    public void EventClear()
    {
        StopTimer();
        GameManager.Instance.EventClear(eventTime);
    }

    public void StopTimer()
    {
        isPlaying = false;
    }
}
