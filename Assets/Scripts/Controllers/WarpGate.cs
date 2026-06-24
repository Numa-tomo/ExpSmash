using UnityEngine;

public class WarpGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ExplorePartFinish();
        }
    }
}
