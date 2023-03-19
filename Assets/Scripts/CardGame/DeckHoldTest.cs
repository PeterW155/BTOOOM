using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHoldTest : MonoBehaviour
{
    public string[] deckTest;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HoldDeck(string[] deck)
    {
        deckTest = deck;
    }

    public string[] GetDeck()
    {
        return deckTest;
    }
}
