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
    bool endScene = false;

    void Update()
    {
        //Haalt references op en checkt belangrijke game states.
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

        //Checkt of speler dood moet gaan.
        if (health <= 0 && !deathHandled)
        {
            Die();
        }

        //Als speler de laatste overlevende is, start de eindtimer en naar de eindscene.
        if (laatsteSpeler)
        {
            endGameTimer -= Time.deltaTime;

            if (endGameTimer <= 0 && !endScene)
            {
                endScene = true;
                SceneManager.LoadScene("scorescene");
            }
        }
    }

    void Die()
    {
        //Zorgt dat death logic maar 1x gebeurt.
        deathHandled = true;
        isAlive = false;

        GiveScore();
        GetPlayerOffScreen();
    }

    void GiveScore()
    {
        //Bepaalt score op basis van hoeveel spelers nog leven.
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
                //Laatste speler krijgt bonus en triggert eindgame.
                earnedScore = 150;
                laatsteSpeler = true;
                break;
        }

        //Voeg score toe aan speler.
        playerManager.points += earnedScore;
    }

    void GetPlayerOffScreen()
    {
        //Zet physics uit zodat speler niet meer beweegt.
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        //Verplaatst speler naar “death position” buiten de map.
        transform.position = deathPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Negeer collisions als speler al dood is.
        if (!isAlive) return;

        //Als je geraakt wordt door een fireball, verlies je health.
        if (other.CompareTag("FireBall"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}