using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleUI : MonoBehaviour
{
    public static TitleUI Instance;

    [SerializeField]
    private Slider timeSlider;

    [SerializeField]
    private Slider targetSlider;

    [SerializeField]
    private TMP_Text timeVelueText;

    [SerializeField]
    private TMP_Text targetValueText;

    private void Awake()
    {
        Instance = this;
    }

    public void InitSliderValue()
    {
        timeSlider.value = GameSettingsManager.Instance.exploreTime;
        targetSlider.value = GameSettingsManager.Instance.targetCount;
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
