using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 20f;

    [SerializeField]
    private float moveSpeed = 2f;

    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            startPos +
            Vector3.right *
            Mathf.Sin(
                Time.time * moveSpeed
            ) *
            moveDistance;
    }
}
