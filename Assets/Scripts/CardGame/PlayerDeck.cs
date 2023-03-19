using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<GameObject> deck;
    public AllCards allCards;
    public object holdDeck;
    public DeckHoldTest deckHoldTest;
    public string[] deckString;
    public int[] deckInt;
    public int missingCards;
    

    private void Start()
    {
        missingCards = 0;
        Debug.Log("The start of the playerDeck ran");
        holdDeck = PhotonNetwork.LocalPlayer.CustomProperties["PlayerDeck"];
        deckHoldTest = FindObjectOfType<DeckHoldTest>();
        deckString = deckHoldTest.GetDeck();

        deckInt = Array.ConvertAll<string, int>(deckString, int.Parse);
        Debug.Log(deckInt);
        if (PhotonNetwork.IsMasterClient)
        {
            deck = allCards.GetCards(deckInt);
        }
        else
        {
            deck = allCards.GetEnemyCards(deckInt);
        }
        
        //foreach (string x in holdDeck)
        //Debug.Log(holdDeck2);
    }


    public void AssignDeck(int[] cards)
    {
        deck = allCards.GetCards(cards);
    }

    public GameObject DrawCard()
    {

        int place = UnityEngine.Random.Range(0, deck.Count);
        Debug.Log("Trying to pull card " + place + ". From deck size " + deck.Count);
        missingCards = missingCards + 1;
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
