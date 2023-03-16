using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public string[] deckids;
    public string[] deckNames;
    public string[][] decks;

    public void Message(int number)
    {
        Debug.Log("Unity says the number of the day is " + number);
    }

    public void PlayerDecks(string[] ids, string[] names, string[][] playerDecks)
    {
        deckids = ids;
        deckNames = names;
        decks = playerDecks;
    }
}
