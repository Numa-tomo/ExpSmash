using UnityEngine;

public class ExploreSceneInitializer : MonoBehaviour
{
    private void Start()
    {
        PlayerStatusManager.Instance.InitStatus();
        GameManager.Instance.ResetGame();
        // カーソル固定・見えなくする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Init");
    }
}
