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
        GameManager.Instance.StartExplore();
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

        TitleUI.Instance.UpdateDisplay();
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
