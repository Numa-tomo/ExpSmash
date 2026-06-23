using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

        timeText.text = $"Time : {GameManager.Instance.LastEventTime:F2} sec";
    }

    public void ReturnExplore()
    {
        SceneManager.LoadScene("ExploreScene");
    }

    public void ReturnTitle()
    {
        PlayerStatusManager.Instance.InitStatus();
        GameManager.Instance.ResetGameFlags();
        SceneManager.LoadScene("TitleScene");
    }
}
