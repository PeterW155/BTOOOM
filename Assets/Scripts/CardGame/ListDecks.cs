using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ListDecks : MonoBehaviour
{
    public List<string> deckIds;
    public TMP_Dropdown dropdown;
    public List<TMP_Dropdown.OptionData> someList;
    public SetPlayerDeck setPlayerDeck;
    public DeckHoldTest please;

    public bool demoState;


    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        demoState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeckIds(List<string> ids)
    {
        Debug.Log("The decks are getting listed");
        deckIds = ids;
        someList = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < ids.Count; i++)
        {
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = ids[i];
            someList.Add(newData);
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(someList);
    }

    public void OnChange_SetPlayerDeck()
    {
        if (demoState)
        {
            int place = dropdown.value;
            Debug.Log(place);
            string[] playerDeck = setPlayerDeck.GetDeck(place);
            _myCustomProperties["PlayerDeck"] = playerDeck;
            //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
            PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
            please.HoldDeck(playerDeck);
        }
        else
        {
            Debug.Log("Demo Decks set");
            int place = dropdown.value;
            Debug.Log("Chose deck" + place);
            string[] playerDeck = setPlayerDeck.GetDemoDeck(place);
            _myCustomProperties["PlayerDeck"] = playerDeck;
            //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
            PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
            please.HoldDeck(playerDeck);
        }
        
    }

    public void SetDemoState(bool setState)
    {
        demoState = setState;
    }
}
