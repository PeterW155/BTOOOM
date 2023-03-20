using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOverall : MonoBehaviour
{
    
    private int player2Count;
    private int player1Count;

    public GameObject player1Win;
    public GameObject player2Win;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerGainPoint(int player)
    {
        if (player == 1)
        {
            player1Count = player1Count + 1;
        }
        if (player == 2)
        {
            player2Count = player2Count + 1;
        }
        if(player1Count >= 5)
        {
            PlayerWin(1);
        }
        if(player2Count >= 5)
        {
            PlayerWin(2);
        }
    }

    public void PlayerLosePoint(int player)
    {
        if (player == 1)
        {
            player1Count = player1Count - 1;
        }
        if (player == 2)
        {
            player2Count = player2Count - 1;
        }
    }

    public void PlayerWin(int player)
    {
        if(player == 1)
        {
            player1Win.SetActive(true);
        }
        if(player == 2)
        {
            player2Win.SetActive(true);
        }
    }
}
