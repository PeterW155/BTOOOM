using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBomb : MonoBehaviour
{

    public bool badaBoom;

    // Update is called once per frame
    void Update()
    {
        if (badaBoom)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Debug.Log("Boom");
        badaBoom = false;
        Invoke("GoAway", 1);
    }

    public void GoAway()
    {
        Destroy(this.gameObject);
    }

}
