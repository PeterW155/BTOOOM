using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ListDecks : MonoBehaviour
{
    public List<int> deckIds;
    public TMP_Dropdown dropdown;
    public List<TMP_Dropdown.OptionData> someList;
    public SetPlayerDeck setPlayerDeck;


    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeckIds(List<int> ids)
    {
        Debug.Log("The decks are getting listed");
        deckIds = ids;
        someList = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < ids.Count; i++)
        {
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = ids[i].ToString();
            someList.Add(newData);
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(someList);
    }

    public void OnChange_SetPlayerDeck()
    {
        int place = dropdown.value;
        Debug.Log(place);
        Deck playerDeck = setPlayerDeck.GetDeck(place);
        _myCustomProperties["PlayerDeck"] = playerDeck;
        //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
    }
}
