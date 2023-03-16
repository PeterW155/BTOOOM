using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoDecks : MonoBehaviour
{
    public List<Deck> demoDecks;
    public SetPlayerDeck setPlayerDeck;
    public List<int> demoIds;

    // Start is called before the first frame update
    void Start()
    {
        demoIds.Add(1);
        demoIds.Add(2);
        demoIds.Add(3);
        demoIds.Add(4);
        demoIds.Add(5);
        print(demoIds);
        //demoDecks = new Deck[1];

        /*Deck hold = new Deck();
        hold.id = "0";
        hold.deckName = "0";
        string[] pls = { "1", "2", "3" };
        hold.cards = pls;
        demoDecks.Add(hold);
        Debug.Log(demoDecks);*/


        /*demoDecks[0].id = "0";
        demoDecks[1].id = "1";
        demoDecks[2].id = "2";
        demoDecks[3].id = "3";

        demoDecks[0].deckName = "0";
        demoDecks[1].deckName = "1";
        demoDecks[2].deckName = "2";
        demoDecks[3].deckName = "3";

        string[] cardDemo = { "1", "2", "3" };

        demoDecks[0].cards = cardDemo;
        demoDecks[1].cards = cardDemo;
        demoDecks[2].cards = cardDemo;
        demoDecks[3].cards = cardDemo;*/


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_DemoDecks()
    {
        Debug.Log("Setting Demo decks");
        setPlayerDeck.DemoDecks(demoIds);
    }
}
