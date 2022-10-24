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

    public GameObject[] bombs;

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
            currentBomb.GetComponent<Animation>().Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ThrowBomb();
            Invoke("SetBomb", 1);
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
}
