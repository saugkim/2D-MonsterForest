using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GateToTheBoss : MonoBehaviour {

    public bool isPlayerInGate;

    void Start()
    {
        isPlayerInGate = false;
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isPlayerInGate = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInGate = false;
        }
    }
}
