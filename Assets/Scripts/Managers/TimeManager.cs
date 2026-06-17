using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField]
    private float timeLimit = 180f;

    public float remainingTime
    {
        get;
        private set;
    }

    [SerializeField]
    private TextMeshProUGUI timerText;

    private void Awake()
    {
        Instance = this;

        remainingTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;

        if(remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);

        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
