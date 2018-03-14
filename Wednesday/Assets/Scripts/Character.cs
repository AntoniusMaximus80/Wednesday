using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public PathGridManager _pathGridManager;
    public float _speed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
