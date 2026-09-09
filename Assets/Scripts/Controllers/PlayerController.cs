using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float dashPower = 2f;

    [SerializeField] // 重力の作成
    private float gravity = -9.81f;

    [SerializeField]
    private float jumpHeight = 2f;

    [SerializeField]
    private Transform cameraTarget;

    [SerializeField] // メインカメラ
    private Transform cameraTransform;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform muzzle;

    private float verticalVelocity = -2f;

    private bool wasGrounded = false;

    public bool canControl = false;

    private CharacterController characterController;

    private CameraTargetController cameraTargetController;

    private MovingPlatform currentPlatform;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraTargetController = GetComponentInChildren<CameraTargetController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!canControl) {characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime); return; }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isGrounded = characterController.isGrounded;

        if(!isGrounded) { currentPlatform = null; }

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        
        float currentMoveSpeed = moveSpeed + PlayerStatusManager.Instance.speed * 0.5f;
        float currentJumpHeight = jumpHeight + PlayerStatusManager.Instance.jump * 0.3f;
        float currentGravity = gravity - PlayerStatusManager.Instance.gravity * 2f;

        // ダッシュ検知
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed = currentMoveSpeed * dashPower;
        }

        // 動く床検知
        Vector3 platformMovement = Vector3.zero;
        if(currentPlatform != null)
        {
            platformMovement = currentPlatform.DeltaPosition;
        }

        // 平面移動
        characterController.Move(move * currentMoveSpeed * Time.deltaTime);

        // 床移動
        characterController.Move(platformMovement);

        // 上下対応
        characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);

        // 重力に関する処理
        if(isGrounded)
        {
            if(verticalVelocity < 0)
            {
                verticalVelocity = -2f; // init
            }
        }
        else if(wasGrounded && verticalVelocity < 0)
        {
            verticalVelocity = 0;
        }

        if(Input.GetButton("Jump") && isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(currentJumpHeight * -2f * currentGravity);
        }

        verticalVelocity += currentGravity * Time.deltaTime;

        if(transform.position.y <= 0) // 落下時の処理
        {
            transform.position = new Vector3(0, 1, 0);
        }

        // 弾発射
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = PoolManager.Instance.GetBullet();

            if(bullet != null)
            {
                bullet.transform.position = muzzle.position;
                bullet.transform.rotation = muzzle.rotation;
                bullet.SetActive(true);
            }
        }

        wasGrounded = isGrounded;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        MovingPlatform platform = hit.gameObject.GetComponent<MovingPlatform>();

        if (platform != null)
        {
            currentPlatform = platform;
        }
    }

    public void SpawnAt(Transform spawnPoint)
    {
        characterController.enabled = false;
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        characterController.enabled = true;

        cameraTargetController.ResetView();
    }
}
