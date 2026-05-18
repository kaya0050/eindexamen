using UnityEngine;
using UnityEngine.InputSystem;

public class cardpull : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
        
    }

    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit)){
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
            if (hit.collider.tag == "card" && Mouse.current.leftButton.wasPressedThisFrame)
            {
                cardscript card = hit.collider.gameObject.GetComponent<cardscript>();
                card.UseCard();
            }
            else if(hit.collider.tag == "card")
            {
                cardscript card = hit.collider.gameObject.GetComponent<cardscript>();
                card.HighlightCard();
            }

        }
    }
    
}
