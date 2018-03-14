using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomOrbit : MonoBehaviour {

    public float _distanceToParent;

    public float _speed;

    public float _angle;

    private float _wobbleAngle;

    public float _wobbleHeight;

    public float _wobbleSpeed;

    // Update is called once per frame
    void Update () {
        _angle += _speed * Time.deltaTime;
        Vector3 _movement = new Vector3(Mathf.Cos(_angle), 0f, Mathf.Sin(_angle));
        _movement *= _distanceToParent;

        _wobbleAngle += _wobbleSpeed * Time.deltaTime;
        Vector3 _wobbleMovement = new Vector3(0f, Mathf.Sin(_wobbleAngle), 0f);
        _wobbleMovement *= _wobbleHeight;

        _movement += _wobbleMovement;
        transform.localPosition = _movement;
    }
}
