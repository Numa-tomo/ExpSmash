using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField]
    private float lifeTime = 5f;

    private float timer;

    private void OnEnable()
    {
        timer = 0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= lifeTime)
        {
            gameObject.SetActive(false);
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
