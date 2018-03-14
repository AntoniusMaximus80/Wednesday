using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour {

    public GameObject _position1,
        _position2;

    private Vector3 _startingPosition;

    public float _duration;

    private float _startTime;

    private float _distance;

	// Use this for initialization
	void Start () {
        _startTime = Time.time;
        _startingPosition = _position1.transform.position;
	}

    // Update is called once per frame
    void Update () {
        float ratio = (Time.time - _startTime) / _duration;
        _position1.transform.position = Vector3.Lerp(_position1.transform.position, _position2.transform.position, ratio);

        if (ratio >= 1f)
        {
            _startTime = Time.time;
            _position2.transform.position = _startingPosition;
            _startingPosition = _position1.transform.position;
        }
	}
}
