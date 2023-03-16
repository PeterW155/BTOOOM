using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    public int[] playerDecks;
    public CallFrontEnd callFrontEnd;

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

        _text.text = result.ToString();

        _myCustomProperties["RandomNumber"] = result;
        //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);

        //Going to use custom properties to hold information like player health
    }

    public void SetName(string name)
    {
        PhotonNetwork.NickName = name;
    }

    public void GetDecks(int[] decks)
    {
        playerDecks = decks;
    }

    private void SetPlayerName()
    {
        PhotonNetwork.NickName = _text.text;
    }

    public void OnClick_Button()
    {
        callFrontEnd.SomeMethod();
        //SetPlayerName();
        //SetCustomNumber();
    }
}
