using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int itemCount;

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
        if(TimeManager.Instance.remainingTime <= 0)
        {
            Debug.Log("Time Up!!");
        }
    }
}
