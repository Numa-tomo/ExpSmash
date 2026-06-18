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
            Target target = other.GetComponent<Target>();
            if(target != null)
            {
                target.DestroyTarget();
            }

            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
