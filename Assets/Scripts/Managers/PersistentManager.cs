using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    private static PersistentManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
