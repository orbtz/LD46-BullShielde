using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    public EndState end;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            end.Die = true;
        }
    }
}
