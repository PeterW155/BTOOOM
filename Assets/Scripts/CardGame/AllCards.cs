using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCards : MonoBehaviour
{
    public GameObject[] cards;
    public List<GameObject> GetCards(int[] Cards)
    {
        List<GameObject> hold = new List<GameObject>();
        for (int i = 0; i < Cards.Length; i++)
        {
            hold.Add(cards[Cards[i]]);
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
}
