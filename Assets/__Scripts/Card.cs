using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
<<<<<<< Updated upstream:Assets/__Scripts/Card.cs
=======
    
    string cardName;
    string cardSuit;
    string cardType;
    string cardAbility;
>>>>>>> Stashed changes:Assets/Card.cs
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private bool mouse_over = false;

    // Update is called once per frame
    void Update()
    {
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.Translate(0,0,2);
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.Translate(0,0,-2);
        mouse_over = false;
        Debug.Log("Mouse exit");
    }
    
}