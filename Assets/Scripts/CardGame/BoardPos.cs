using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BoardPos : MonoBehaviour
{

    public GameObject card;
    public Card currCard;
    public bool hasCard;
    public int playerControl;
    public PlayerManager playerManager;
    public AllCards allCards;
    public TurnManager turnManager;
    public BoardOverall boardOverall;

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
            Debug.Log("A card has DIED");
            hasCard = false;
            Destroy(card.gameObject);
            currCard = null;
            boardOverall.PlayerLosePoint(playerControl);
            playerControl = 0;
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
        Debug.Log("This position belongs to " + playerControl);
        //int place = playerManager.activeHand.GetComponentInChildren<Card>().id;
        //Debug.Log("The card id is " + place);

        //GameObject hold;

        if(playerManager.CanGo() && playerManager.activeHand != null && !hasCard)
        {
            int playerHold;
            int place = playerManager.activeHand.GetComponentInChildren<Card>().id;
            Debug.Log("The card id is " + place);
            if (turnManager.card == 1)
            {
                playerHold = 1;
                turnManager.card = 2;
            }
            else
            {
                playerHold = 2;
                turnManager.card = 1;
            }

            //card = MainManager.NetworkInstantiate(hold, this.transform.position, Quaternion.identity);
            //card = Instantiate(hold, this.transform.position, Quaternion.identity);
            //card.transform.parent = this.transform;
            //currCard = card.GetComponent<Card>();

            //hasCard = true;
            //playerControl = playerManager.playerNumber;

            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("SpawnCard", RpcTarget.All, place, playerHold);

            playerManager.TurnTaken();
        }
    }

    [PunRPC]
    public void SpawnCard(int id, int player)
    {
        GameObject hold;
        if (player == 1)
        {
            hold = allCards.GetCard1(id);
        }
        else
        {
            hold = allCards.GetCard2(id);
        }

        card = Instantiate(hold, this.transform.position, Quaternion.identity);
        card.transform.SetParent(this.transform);
        //card.transform.parent = this.transform;
        currCard = card.GetComponent<Card>();
        PlayCard(currCard.attack);

        hasCard = true;
        playerControl = playerManager.playerNumber;
        boardOverall.PlayerGainPoint(playerControl);
    }
}
