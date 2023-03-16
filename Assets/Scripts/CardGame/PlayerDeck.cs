using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<GameObject> deck;
    public AllCards allCards;

    
    public void AssignDeck(int[] cards)
    {
        deck = allCards.GetCards(cards);
    }

    public GameObject DrawCard()
    {

        int place = UnityEngine.Random.Range(0, deck.Count);
        GameObject card = deck[place];

        deck.RemoveAt(place);
        
        /*for(int i = place; i < deck.Count - 1; i++)
        {
            deck[i] = deck[i + 1];
        }
        Array.Resize(ref deck, deck.Count - 1);*/

        return card;
    }
}
