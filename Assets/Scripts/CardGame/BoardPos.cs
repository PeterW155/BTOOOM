using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPos : MonoBehaviour
{

    public GameObject card;
    public Card currCard;
    public bool hasCard;
    public int playerControl;
    public PlayerManager playerManager;
    public AllCards allCards;

    public BoardPos up;
    public BoardPos down;
    public BoardPos left;
    public BoardPos right;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitCard(int damage)
    {
        if (currCard.Hit(damage))
        {
            hasCard = false;
            Destroy(card.gameObject);
        }
    }

    public void PlayCard(int damage)
    {
        if(up != null && up.hasCard)
        {
            up.HitCard(damage);
        }
        if (down != null && down.hasCard)
        {
            down.HitCard(damage);
        }
        if (left != null && left.hasCard)
        {
            left.HitCard(damage);
        }
        if (right != null && right.hasCard)
        {
            right.HitCard(damage);
        }
        hasCard = true;
        
    }

    public void TriggerCard(int damage)
    {
        if (up != null && up.hasCard)
        {
            up.HitCard(damage);
        }
        if (down != null && down.hasCard)
        {
            down.HitCard(damage);
        }
        if (left != null && left.hasCard)
        {
            left.HitCard(damage);
        }
        if (right != null && right.hasCard)
        {
            right.HitCard(damage);
        }
    }

    public void OnClick_ThisBoardPos()
    {
        Debug.Log("You clicked one of the board positions");
        //int place = playerManager.activeHand.GetComponentInChildren<Card>().id;
        //Debug.Log("The card id is " + place);

        GameObject hold;

        if(playerManager.CanGo() && playerManager.activeHand != null && !hasCard)
        {
            int place = playerManager.activeHand.GetComponentInChildren<Card>().id;
            Debug.Log("The card id is " + place);
            if (playerManager.playerNumber == 1)
            {
                hold = allCards.GetCard1(place);
            }
            else
            {
                hold = allCards.GetCard2(place);
            }

            card = MainManager.NetworkInstantiate(hold, this.transform.position, Quaternion.identity);
            card.transform.parent = this.transform;
            currCard = card.GetComponent<Card>();

            hasCard = true;
            playerControl = playerManager.playerNumber;

            playerManager.TurnTaken();
        }
    }
}
