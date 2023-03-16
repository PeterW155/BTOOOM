using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerDeck : MonoBehaviour
{
    public List<Deck> playerDecks;
    public ListDecks listDecks;
    public List<int> ids;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDecks(Deck[] decks)
    {
        for (int i = 0; i < decks.Length; i++)
        {
            playerDecks.Add(decks[i]);
        }
        
        Debug.Log("Unity has the decks");
        Debug.Log(playerDecks);

        foreach (Deck deck in playerDecks)
        {
            ids.Add(int.Parse(deck.id));
        }
        listDecks.SetDeckIds(ids);
    }

    public void DemoDecks(List<int> idsDemo)
    {
        /*playerDecks = decks;
        Debug.Log("Unity has the decks");
        Debug.Log(playerDecks);

        foreach (Deck deck in playerDecks)
        {
            ids.Add(int.Parse(deck.id));
        }*/
        listDecks.SetDeckIds(idsDemo);
    }

    public Deck GetDeck(int place)
    {
        return playerDecks[place];
    }
}
