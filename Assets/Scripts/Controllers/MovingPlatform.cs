using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float xMoveDistance = 20f;

    [SerializeField]
    private float yMoveDistance = 20f;

    [SerializeField]
    private float xMoveSpeed = 2f;

    [SerializeField]
    private float yMoveSpeed = 2f;

    [SerializeField]
    private bool moveX = true;

    [SerializeField]
    private bool moveY = true;

    private Vector3 startPos;
    private Vector3 movePos;

    private Vector3 previousPos;

    public Vector3 DeltaPosition { get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        previousPos = transform.position;
        DeltaPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movePos = new Vector3(0, 0, 0);
        if (moveX)
        {
            movePos += Vector3.right * Mathf.Cos(Time.time * xMoveSpeed) * xMoveDistance;
        }
        if (moveY)
        {
            movePos += Vector3.up * Mathf.Sin(Time.time * yMoveSpeed) * yMoveDistance;
        }
        transform.position =
            startPos +
            movePos;

        DeltaPosition = transform.position - previousPos;
        previousPos = transform.position;
    }
}
