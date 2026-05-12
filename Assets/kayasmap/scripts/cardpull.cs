using UnityEngine;

public class cardpull : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit)){
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
            if (hit.collider.tag == "card")
            {
                cardscript card = hit.collider.gameObject.GetComponent<cardscript>();
                card.UseCard();
            }
        }
    }
}
