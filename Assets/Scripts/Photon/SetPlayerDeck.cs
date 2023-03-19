using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerDeck : MonoBehaviour
{
    
    public ListDecks listDecks;
    public List<string> deckNames;
    public List<string[]> decks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDecks(string[] deckID, string[] deckName, string[][] cards)
    {
        for (int i = 0; i < deckID.Length; i++)
        {
            deckNames.Add(deckName[i]);
            decks.Add(cards[i]);
        }
        
        Debug.Log("Unity has the decks");
        Debug.Log(deckNames);

        
        listDecks.SetDeckIds(deckNames);
    }

    public void DemoDecks(List<string> idsDemo)
    {
        /*playerDecks = decks;
        Debug.Log("Unity has the decks");
        Debug.Log(playerDecks);

        foreach (Deck deck in playerDecks)
        {
            ids.Add(int.Parse(deck.id));
        }*/
        listDecks.SetDeckIds(idsDemo);
        listDecks.SetDemoState(true);
    }

    public string[] GetDeck(int place)
    {
        return decks[place];
    }

    public string[] GetDemoDeck(int place)
    {
        string[] hold1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        string[] hold2 = { "2", "2", "2", "2", "2", "2", "2", "2", "2", "2" };
        string[] hold3 = { "3", "3", "3", "3", "3", "3", "3", "3", "3", "3" };
        string[] hold4 = { "4", "4", "4", "4", "4", "4", "4", "4", "4", "4" };
        string[] hold5 = { "5", "5", "5", "5", "5", "5", "5", "5", "5", "5" };
        string[][] holdall = { hold1, hold2, hold3, hold4, hold5 };
        return holdall[place];
    }
}
