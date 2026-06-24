using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    public static ResultUI Instance;

    [SerializeField]
    private TMP_Text speedText;

    [SerializeField]
    private TMP_Text jumpText;

    [SerializeField]
    private TMP_Text gravityText;

    [SerializeField]
    private TMP_Text resultText;

    [SerializeField]
    private TMP_Text timeText;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayResults()
    {
        speedText.text =
            "Speed : "
            + PlayerStatusManager.Instance.speed;

        jumpText.text =
            "Jump : "
            + PlayerStatusManager.Instance.jump;

        gravityText.text =
            "Gravity : "
            + PlayerStatusManager.Instance.gravity;

        if (GameManager.Instance.IsEventClear)
        {
            resultText.text = "CLEAR!";
        }
        else
        {
            resultText.text = "FAILED...";
        }
    }

    public void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int miliseconds = Mathf.FloorToInt(time * 100) % 100;

        timeText.text = $"Time : {minutes:00}:{seconds:00}:{miliseconds:00}";
    }
}
