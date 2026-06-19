using Unity.VisualScripting;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    public static GameSettingsManager Instance;

    [Header("Explore")]
    public float exploreTime = 180f;

    [Header("Event")]
    public int targetCount = 5;

    private void Awake()
    {
        Instance = this;
    }
}
