using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ExploreScene");
    }
    
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
