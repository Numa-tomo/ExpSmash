using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int itemCount;

    [SerializeField]
    private float remainTime = 180f;

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
        remainTime -= Time.deltaTime;

        if(remainTime <= 0)
        {
            remainTime = 0;
            Debug.Log("Game Over");
        }
        
        Debug.Log($"のこり {remainTime}");
    }
}
