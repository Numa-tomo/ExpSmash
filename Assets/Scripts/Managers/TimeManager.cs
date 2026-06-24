using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField]
    private float timeLimit = 180f;

    public float remainingTime { get; private set; }

    [SerializeField]
    private TextMeshProUGUI timerText;

    private void Awake()
    {
        Instance = this;
        timeLimit = GameSettingsManager.Instance.exploreTime;
        DisplayTime(timeLimit);
    }

    private void Update()
    {
        if(!IsCountStart()){ return; }

        remainingTime -= Time.deltaTime;

        if(remainingTime < 0)
        {
            remainingTime = 0;
            ExploreManager.Instance.ExploreFinish();
        }

        DisplayTime(remainingTime);
    }

    public void InitTimer()
    {
        remainingTime = timeLimit;
    }

    private void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);

        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private bool IsCountStart()
    {
        if (CountDownManager.Instance.IsFinished)
        {
            return true;
        }

        return false;
    }
}
