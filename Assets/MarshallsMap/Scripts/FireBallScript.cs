using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public bool hasHit = false;

    public float moveSpeed = 1f;
    public float lifeTime = 1f;

    private void Start()
    {
        //Zorgt dat de fireball zichzelf automatisch verwijdert na een bepaalde tijd.
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        //Laat de fireball constant naar beneden bewegen.
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Voorkomt dat de speler meerdere keren wordt geraakt.
        if (hasHit) return;

        //Als de fireball een speler of de grond raakt verdwijnt die.
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            hasHit = true;
            Destroy(gameObject);
        }
    }
}