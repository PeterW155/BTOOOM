using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public int health;
    public int attack;
    public BoardPos boardPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCard(BoardPos boardPos)
    {
        boardPos.currCard = this;
        boardPos.card = this.gameObject;
        this.transform.position = boardPos.transform.position;
        boardPos.PlayCard(attack);
    }

    public bool Hit(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            return true;
        }
        return false;
    }


}
