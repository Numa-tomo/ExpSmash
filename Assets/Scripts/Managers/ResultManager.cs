using TMPro;
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
    }

    public void ReturnExplore()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("ExploreScene");
    }
}
