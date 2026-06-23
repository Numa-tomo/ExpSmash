using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void GoToEvent()
    {
        SceneManager.LoadScene("EventScene");
    }

    public void ExplorePartFinish()
    {
        if(TimeManager.Instance.remainingTime <= 0)
        {
            IsTimeUp = true;
        }
        SceneManager.LoadScene("EventScene");
    }

    public void EventClear(float clearTime)
    {
        LastEventTime = clearTime;
        IsEventClear = true;
        SceneManager.LoadScene("ResultScene");
    }

    public void ResetGameFlags()
    {
        IsTimeUp = false;
        IsEventClear = false;
    }
}
