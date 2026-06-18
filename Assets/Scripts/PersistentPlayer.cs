using UnityEngine;

public class PersistentPlayer : MonoBehaviour
{
    private static PersistentPlayer Instance;

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
