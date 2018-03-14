using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickAxis : MonoBehaviour {

    public float _xRotationSpeed,
        _yRotationSpeed,
        _zRotationSpeed;

    private float _xRotation,
        _yRotation,
        _zRotation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _xRotation += _xRotationSpeed * Time.deltaTime;
        _yRotation += _yRotationSpeed * Time.deltaTime;
        _zRotation += _zRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, _zRotation);
    }
}
