using UnityEngine;

public class pickupscript : MonoBehaviour
{
    public int points;
    public int deathTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
            playermanager player = collision.gameObject.GetComponent<playermanager>();
            player.points += points;
            Destroy(gameObject);
        }
    }
}
