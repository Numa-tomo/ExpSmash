using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager Instance;

    public int speed = 0;
    public int jump = 0;
    public int gravity = 0;

    private void Awake()
    {
        Instance = this;
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