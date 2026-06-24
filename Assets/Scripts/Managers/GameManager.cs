using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GamePhase CurrentPhase {get; private set;}

    public bool IsTimeUp {get; private set;}

    public bool IsEventClear {get; private set;}

    public float LastEventTime {get; private set;}

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartExplore()
    {
        PlayerStatusManager.Instance.InitStatus();
        ResetRunData();
        CurrentPhase = GamePhase.Explore;
        SceneManager.LoadScene("ExploreScene");
    }

    public void StartEvent()
    {
        CurrentPhase = GamePhase.Event;
    }

    public void StartResult()
    {
        CurrentPhase = GamePhase.Result;
    }

    public void ExplorePartFinish()
    {
        if(TimeManager.Instance.remainingTime <= 0)
        {
            IsTimeUp = true;
        }
        StartEvent();
        SceneManager.LoadScene("EventScene");
    }

    public void EventClear(float clearTime)
    {
        LastEventTime = clearTime;
        IsEventClear = true;
        StartResult();
        SceneManager.LoadScene("ResultScene");
    }

    public void ResetRunData()
    {
        IsTimeUp = false;
        IsEventClear = false;
        LastEventTime = 0f;
    }
}
