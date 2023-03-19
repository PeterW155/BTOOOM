using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public int turn;

    // Start is called before the first frame update
    void Start()
    {
        turn = 1;
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
        Debug.Log("The next turn function has happened");
        if (turn == 1)
        {
            turn = 2;
        }
        else if(turn == 2)
        {
            turn = 1;
        }
    }
}
