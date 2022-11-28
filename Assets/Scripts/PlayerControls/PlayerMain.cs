using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayerMain : MonoBehaviour
{

    public int health;
    public bool holdingBomb;
    public Transform hand;
    public TMP_Text healthShow;

    public GameObject currentBomb;
    public GameObject bombType;

    public int bombNumber;
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;

    public GameObject[] triggerBombs;
    public int triggerBombNumber;

    private const byte LOSE_EVENT = 1;
    private string winner;
    public GameObject winScreen;
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        currentBomb = MainManager.NetworkInstantiate(bombType, hand.transform.position, Quaternion.identity);
        triggerBombs = new GameObject[3];
        healthShow = GameObject.Find("Health").GetComponent<TMP_Text>();
        healthShow.text = "Health: " + health;
        loseScreen = GameObject.Find("LoseScreen");
        loseScreen.SetActive(false);
        winScreen = GameObject.Find("WinScreen");
        winScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBomb)
        {
            currentBomb.transform.position = hand.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(bombNumber == 0)
            {
                currentBomb.GetComponent<BombsMain>().trigger();
            }
            else if(bombNumber == 1)
            {
                if (triggerBombs[triggerBombNumber] != null)
                    triggerBombs[triggerBombNumber].GetComponent<BombsMain>().trigger();
                triggerBombs[triggerBombNumber] = currentBomb.gameObject;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ThrowBomb();
            Invoke("SetBomb", 1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateBomb(1);
            //TakeDamage(5);
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateBomb(-1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(triggerBombs[triggerBombNumber] != null)
            {
                triggerBombs[triggerBombNumber].GetComponent<BombsMain>().trigger();
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            triggerBombNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            triggerBombNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            triggerBombNumber = 2;
        }
        /*if (triggerBombs[1] != null)
        {
            triggerBombs[1].GetComponent<Animator>().SetBool("Trigger", true);
        }*/


    }

    private void ThrowBomb()
    {
        currentBomb.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        currentBomb.GetComponent<Rigidbody>().AddForce(transform.up * 3f, ForceMode.Impulse);
        currentBomb = null;
        holdingBomb = false;
        //currentBomb = MainManager.NetworkInstantiate(bombType, hand.transform.position, Quaternion.identity);
    }

    private void SetBomb()
    {
        currentBomb = MainManager.NetworkInstantiate(bombType, hand.transform.position, Quaternion.identity);
        holdingBomb = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthShow.text = "Health: " + health;
        if (health <= 0)
        {
            PlayerLose();
        }
    }

    public void RotateBomb(int direction)
    {
        Destroy(currentBomb.gameObject);
        bombNumber += direction;
        if (bombNumber > 2) bombNumber = 0;
        if (bombNumber < 0) bombNumber = 2;
        if (bombNumber == 0)
        {
            currentBomb = MainManager.NetworkInstantiate(bomb1, hand.transform.position, Quaternion.identity);
            bombType = bomb1;

        }
        if (bombNumber == 1)
        {
            currentBomb = MainManager.NetworkInstantiate(bomb2, hand.transform.position, Quaternion.identity);
            bombType = bomb2;
        }
        if (bombNumber == 2)
        {
            currentBomb = MainManager.NetworkInstantiate(bomb3, hand.transform.position, Quaternion.identity);
            bombType = bomb3;
        }
    }

    public void PlayerLose()
    {
        Debug.Log("This player loses do the lose stuff");
        object[] nothing = new object[] { 1, 2, 3, };
        PhotonNetwork.RaiseEvent(LOSE_EVENT, nothing, RaiseEventOptions.Default, SendOptions.SendReliable);
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayerWins()
    {
        Debug.Log("You won");
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(ExitGames.Client.Photon.EventData obj)
    {
        if (obj.Code == LOSE_EVENT)
        {
            PlayerWins();
        }
    }
}
