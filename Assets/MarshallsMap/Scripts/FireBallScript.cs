using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public bool hasHit = false;

    public float moveSpeed = 1f;
    public float lifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            hasHit = true;
            Destroy(gameObject);
        }
    }
}
