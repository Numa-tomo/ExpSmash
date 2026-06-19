using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager Instance;

    public int speed {get; private set;}
    public int jump {get; private set;}
    public int gravity {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public void InitStatus()
    {
        speed = 0;
        jump = 0;
        gravity = 0;
    }

    public void AddSpeed()
    {
        speed++;
    }

    public void AddJump()
    {
        jump++;
    }

    public void AddGravity()
    {
        gravity++;
    }
}