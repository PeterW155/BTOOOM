using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCards : MonoBehaviour
{
    public GameObject[] cards;
    public GameObject[] enemyCards;
    public GameObject[] localCards;
    public GameObject[] localEnemyCards;
    public List<GameObject> GetCards(int[] Cards)
    {
        List<GameObject> hold = new List<GameObject>();
        for (int i = 0; i < Cards.Length; i++)
        {
            hold.Add(cards[Cards[i]-1]);
        }

        return hold;
    }
    public List<GameObject> GetEnemyCards(int[] Cards)
    {
        List<GameObject> hold = new List<GameObject>();
        for (int i = 0; i < Cards.Length; i++)
        {
            hold.Add(enemyCards[Cards[i]-1]);
        }

        return hold;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I have the cards");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetCard1(int place)
    {
        return cards[place];
    }

    public GameObject GetCard2(int place)
    {
        return enemyCards[place];
    }
}
