using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPos : MonoBehaviour
{

    public GameObject card;
    public Card currCard;
    public bool hasCard;
    public int playerControl;

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
}
