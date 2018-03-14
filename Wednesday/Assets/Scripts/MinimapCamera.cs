using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    public GameObject _player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPosition = _player.transform.position;
        playerPosition.y = 17.5f;
        transform.position = playerPosition;
    }
}
