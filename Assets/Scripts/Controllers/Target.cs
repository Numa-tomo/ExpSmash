using UnityEngine;

public class Target : MonoBehaviour
{
    public void DestroyTarget()
    {
        EventManager.Instance.TargetDestroyed();
        gameObject.SetActive(false);
    }
}
