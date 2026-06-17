using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI speedText;

    [SerializeField]
    private TextMeshProUGUI jumpText;

    [SerializeField]
    private TextMeshProUGUI gravityText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = $"SPD : {PlayerStatusManager.Instance.speed}";

        jumpText.text = $"JMP : {PlayerStatusManager.Instance.jump}";

        gravityText.text = $"GRV : {PlayerStatusManager.Instance.gravity}";
    }
}
