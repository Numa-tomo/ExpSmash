using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    // 縦方向の回転を制御するファイル
    [SerializeField]
    private float sensitivity = 150f;

    private float pitch;
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(
            Vector3.up,
            mouseX * sensitivity * Time.deltaTime
        );

        pitch -= mouseY * sensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(
            pitch,
            -45f,
            70f
        );

        transform.localRotation = Quaternion.Euler(
            pitch,
            0,
            0
        );
    }

    public void ResetView()
    {
        pitch = 0f;
        transform.localRotation =  Quaternion.Euler(0, 0, 0);
    }
}
