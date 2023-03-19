using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPos : MonoBehaviour
{

    public GameObject card;
    public PlayerDeck playerDeck;
    public PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_ThisPos()
    {
        Debug.Log("Clicked a card in hand");
        if (playerManager.CanGo())
        {
            playerManager.SetActivehand(this.gameObject);
        }
    }

    public void SetHand()
    {
        card = playerDeck.DrawCard();
        Instantiate(card, this.transform);
    }

    public void CardPlayed()
    {
        //card.GetComponent<Card>().KillIt();
        card = playerDeck.DrawCard();
        Instantiate(card, this.transform);
    }
}
