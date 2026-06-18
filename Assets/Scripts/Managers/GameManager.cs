using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int itemCount;

    public bool isTimeUp {get; private set;}

    public bool IsEventClear {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem()
    {
        itemCount++;
        Debug.Log($"取得数 : {itemCount}");
    }

    private void Update()
    {
        
    }

    public void ExplorePartFinish()
    {
        if(TimeManager.Instance.remainingTime <= 0)
        {
            isTimeUp = true;

            Debug.Log("Time Up!!");
        }
        SceneManager.LoadScene("EventScene");
    }

    public void EventClear()
    {
        IsEventClear = true;
        SceneManager.LoadScene("ResultScene");
    }

    public void ResetGame()
    {
        isTimeUp = false;
        IsEventClear = false;
        Debug.Log($"isTimeUp = {isTimeUp}");
        Debug.Log($"remainingTime = {TimeManager.Instance.remainingTime}");
    }
}
