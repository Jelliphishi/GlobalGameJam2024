using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public Text deckSizeText;

    public int size() {
        return deck.Count;
    }

    public void DrawCard()
    {
        if (deck.Count >= 1){
            Card randomCard = deck[Random.Range(0, deck.Count)];

            for(int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true)
                {
                    randomCard.gameObject.SetActive(true);
                    randomCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }
    }

    private void Update()
    {
        deckSizeText.text = deck.Count.ToString();
    }
}
