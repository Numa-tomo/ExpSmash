using UnityEngine;

public class ExploreManager : MonoBehaviour
{
    public static ExploreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ExploreFinish()
    {
        GameManager.Instance.ExplorePartFinish();
    }
}
