using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
