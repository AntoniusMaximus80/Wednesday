using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    /*float x;
    void Update()
    {

        x += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(x, 0, 0);

    }*/

    float yRotation = 0f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        yRotation += Time.deltaTime * 100f;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
	}
}