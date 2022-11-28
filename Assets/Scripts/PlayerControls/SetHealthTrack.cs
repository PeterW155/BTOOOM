using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetHealthTrack : MonoBehaviour
{
    public TMP_Text health;
    public PlayerMain playerMain;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = FindObjectOfType<PlayerMain>();
        playerMain.healthShow = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
