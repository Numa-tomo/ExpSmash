using UnityEditor.Rendering.Universal;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField]
    private PowerUpType powerUpType;

    [SerializeField]
    private float value = 1f;

    // フィールド変数に対するgetメソッドの簡略形
    public PowerUpType ItemType => powerUpType;
    public float Value => value;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")){ return; }
        ApplyPowerUp();
        Destroy(gameObject);
        ItemSpawner.Instance.ItemCollected();
    }

    private void ApplyPowerUp()
    {
        switch(ItemType)
        {
            case PowerUpType.Speed:
                PlayerStatusManager.Instance.speed++;
                break;
            case PowerUpType.Jump:
                PlayerStatusManager.Instance.jump++;
                break;
            case PowerUpType.Gravity:
                PlayerStatusManager.Instance.gravity++;
                break;
        }
    }
}
