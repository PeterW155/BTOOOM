using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    public int health;
    public bool holdingBomb;
    public Transform hand;

    public GameObject currentBomb;
    public GameObject bombType;

    public int bombNumber;
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        currentBomb = MainManager.NetworkInstantiate(bombType, hand.transform.position, Quaternion.identity);

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
            currentBomb.GetComponent<Animator>().SetBool("Trigger", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            ThrowBomb();
            Invoke("SetBomb", 1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateBomb(1);
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateBomb(-1);
        }

        
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

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("This player lost");
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
}
