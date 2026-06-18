using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int itemCount;

    private bool isTimeUp = false;

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
        if(TimeManager.Instance.remainingTime <= 0 && !isTimeUp)
        {
            isTimeUp = true;

            Debug.Log("Time Up!!");
            SceneManager.LoadScene("EventScene");
        }
    }

    public void EventClear()
    {
        Debug.Log("Event Clear!");
    }
}
