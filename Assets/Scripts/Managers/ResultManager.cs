using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ResultUI.Instance.DisplayResults();
        ResultUI.Instance.DisplayTime(GameManager.Instance.LastEventTime);
    }

    public void ReturnExplore()
    {
        GameManager.Instance.StartExplore();
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
