using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptMinigame3 : MonoBehaviour
{
    public int health = 2;
    public int earnedScore;

    public bool isAlive = true;
    private bool deathHandled = false;

    public float endGameTimer = 3f;
    private bool laatsteSpeler = false;

    public Transform deathPosition;

    private UIManagerScript uiManager;
    public playermanager playerManager;

    private Rigidbody rb;

    void Start()
    {

    }

    void Update()
    {
        uiManager = FindAnyObjectByType<UIManagerScript>();

        rb = GetComponent<Rigidbody>();

        GameObject dp = GameObject.Find("DeathPosition");

        if (dp != null)
        {
            deathPosition = dp.transform;
        }
        else
        {
            Debug.LogError("DeathPosition niet gevonden!");
        }

        // speler gaat dood
        if (health <= 0 && !deathHandled)
        {
            Die();
        }

        // timer waarin je de winnaar ziet
        if (laatsteSpeler)
        {
            endGameTimer -= Time.deltaTime;

            if (endGameTimer <= 0)
            {
                SceneManager.LoadScene("scorescene");
            }
        }
    }

    void Die()
    {
        deathHandled = true;
        isAlive = false;

        GiveScore();

        GetPlayerOffScreen();
    }

    void GiveScore()
    {
        switch (uiManager.alivePlayers)
        {
            case 4:
                earnedScore = 0;
                break;

            case 3:
                earnedScore = 50;
                break;

            case 2:
                earnedScore = 100;
                break;

            case 1:
                earnedScore = 150;
                laatsteSpeler = true;
                break;
        }

        playerManager.points += earnedScore;
    }

    void GetPlayerOffScreen()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        transform.position = deathPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAlive) return;

        if (other.CompareTag("FireBall"))
        {
            health--;

            Destroy(other.gameObject);
        }
    }
}