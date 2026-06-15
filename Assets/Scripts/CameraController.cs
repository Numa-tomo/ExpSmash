using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 100f;

    private float pitch = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        pitch -= mouseY * mouseSensitivity * Time.deltaTime;

        // 回転角の制限
        pitch = Mathf.Clamp(
            pitch,
            -60f,
            60f
        );

        // x軸の回転(上下方向)
        transform.localRotation = Quaternion.Euler(
            pitch,
            0f,
            0f
        );
    }
}
