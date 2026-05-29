using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public int points;
    public int deathTime;

    private void FixedUpdate()
    {
        deathTime--;
        if (deathTime < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            player.points += points;
            Destroy(gameObject);
        }
    }
}
