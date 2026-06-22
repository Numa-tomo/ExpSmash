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

    private void Start()
    {
        TitleUI.Instance.InitSliderValue();
    }

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

        TitleUI.Instance.InitSliderValue();
        TitleUI.Instance.UpdateDisplay();
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
