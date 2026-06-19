using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject optionPanel;

    [SerializeField]
    private TMP_InputField timeInput;

    [SerializeField]
    private TMP_InputField targetInput;

    public void StartGame()
    {
        SceneManager.LoadScene("ExploreScene");
    }
    
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OpenOption()
    {
        mainPanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void ApplySettings()
    {
        float time = float.Parse(timeInput.text);
        int target = int.Parse(targetInput.text);

        GameSettingsManager.Instance.exploreTime = time;
        GameSettingsManager.Instance.targetCount = target;
    }
}
