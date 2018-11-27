using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


	void Start ()
    {
        offset = transform.position - player.transform.position;	
	}


	void LateUpdate ()
    {
        if (!GameControl.gameControl.isPlayerInBossRoom)
        {
            transform.position = player.transform.position + offset; //+ offset;
        }
        else
        {
            transform.position = new Vector3(650f, 9f, -10f);
        }
	}

}
