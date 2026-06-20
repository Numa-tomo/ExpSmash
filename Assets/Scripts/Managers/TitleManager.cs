using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject optionPanel;

    [SerializeField]
    private Slider timeSlider;

    [SerializeField]
    private Slider targetSlider;

    [SerializeField]
    private TMP_Text timeVelueText;

    [SerializeField]
    private TMP_Text targetValueText;

    [SerializeField]
    private TextMeshProUGUI applyButtonText;

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

        timeSlider.value = GameSettingsManager.Instance.exploreTime;
        targetSlider.value = GameSettingsManager.Instance.targetCount;
        UpdateDisplay();
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(timeSlider.value / 60);
        int seconds = Mathf.FloorToInt(timeSlider.value % 60);

        timeVelueText.text = $"{minutes:00}:{seconds:00}";
        targetValueText.text = $"{targetSlider.value: 0}";
    }

    public void OnTimeChanged(float value)
    {
        GameSettingsManager.Instance.exploreTime = value;
        UpdateDisplay();
    }

    public void OnTargetChanged(float value)
    {
        GameSettingsManager.Instance.targetCount = Mathf.RoundToInt(value);

        UpdateDisplay();
    }
}
