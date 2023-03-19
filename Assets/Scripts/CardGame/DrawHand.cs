using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHand : MonoBehaviour
{

    public HandPos hand1;
    public HandPos hand2;
    public HandPos hand3;
    public HandPos hand4;
    public HandPos hand5;

    // Start is called before the first frame update
    void Start()
    {
        hand1.SetHand();
        hand2.SetHand();
        hand3.SetHand();
        hand4.SetHand();
        hand5.SetHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
