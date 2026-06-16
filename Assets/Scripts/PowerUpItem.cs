using UnityEditor.Rendering.Universal;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField]
    private PowerUpType itemType;

    [SerializeField]
    private float value = 1f;

    // フィールド変数に対するgetメソッドの簡略形
    public PowerUpType ItemType => itemType;
    public float Value => value;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.AddItem();
            Debug.Log("Power Up!");

            Destroy(gameObject);
        }
    }
}
