using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private int remainingTargets;

    private void Awake()
    {
        Instance = this;
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
