using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField] // 重力の作成
    private float gravity = -9.81f;

    [SerializeField]
    private float jumpHeight = 2f;

    [SerializeField]
    private Transform cameraTarget;

    [SerializeField] // メインカメラ
    private Transform cameraTransform;

    private float verticalVelocity;

    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // カーソル固定・見えなくする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;

        move.y = verticalVelocity; // 重力分

        controller.Move(move * moveSpeed * Time.deltaTime);

        // 重力に関する処理
        if(controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        verticalVelocity += gravity * Time.deltaTime;
    }
}
