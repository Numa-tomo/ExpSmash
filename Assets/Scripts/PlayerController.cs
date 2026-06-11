using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotateSpeed = 150f;

    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;

        controller.Move(move * moveSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(
            Vector3.up,
            mouseX * rotateSpeed * Time.deltaTime
        );
    }
}
