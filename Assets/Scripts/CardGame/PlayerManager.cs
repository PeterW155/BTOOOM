using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;
    public TurnManager turnManager;
    public GameObject turnManagerObject;

    public GameObject activeHand;


    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            playerNumber = 1;
            GameObject hold = MainManager.NetworkInstantiate(turnManagerObject, this.transform.position, Quaternion.identity);
            turnManager = hold.GetComponent<TurnManager>();
        }
        else
        {
            turnManager = FindObjectOfType<TurnManager>();
            playerNumber = 2;
        }
        Debug.Log("You are player " + playerNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanGo()
    {
        if(turnManager.GetTurn() == playerNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetActivehand(GameObject hand)
    {
        activeHand = hand;
    }

    public void TurnTaken()
    {
        activeHand.GetComponent<HandPos>().CardPlayed();
        activeHand = null;
        turnManager.NextTurn();
    }
}
