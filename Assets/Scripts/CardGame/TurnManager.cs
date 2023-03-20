using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TurnManager : MonoBehaviour, IPunObservable
{

    public int turn;
    public int card;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        card = 1;
        turn = 1;
        Debug.Log("The turn manager is ALIVE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetTurn()
    {
        return turn;
    }

    
    public void NextTurn()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("AllRooms", RpcTarget.All);
    }

    [PunRPC]
    public void AllRooms()
    {
        Debug.Log("The next turn function has happened");
        if (turn == 1)
        {
            turn = 2;
        }
        else if (turn == 2)
        {
            turn = 1;
        }
        Debug.Log("The current turn is: " + turn);
    }
}
