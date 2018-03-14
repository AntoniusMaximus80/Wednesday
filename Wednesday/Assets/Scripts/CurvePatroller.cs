using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePatroller : MonoBehaviour {

    [SerializeField]
    private Curve[] _curves;

    [SerializeField]
    private float _duration;

    public EasingType _easingType;

    private float _startTime;

    [SerializeField]
    private GameObject _cubePrefab;

    private GameObject _instantiatedCube;

    private int _curveIndex = 0;

    private bool _returning = false;

    // Use this for initialization
    void Start () {
        _startTime = Time.time;
        _instantiatedCube = Instantiate(_cubePrefab, _curves[0].GetPoint(0f), new Quaternion(0f, 0f, 0f, 0f));
    }
	
	// Update is called once per frame
	void Update () {
        float ratio;
        if (!_returning) {
            ratio = (Time.time - _startTime) / _duration;
        } else
        {
            ratio = 1f - ((Time.time - _startTime) / _duration);
        }
        _instantiatedCube.transform.position = _curves[_curveIndex].GetPoint(ratio);

        if (ratio >= 1f)
        {
            _startTime = Time.time;
            if (!_returning) {
                _curveIndex++;
                if (_curveIndex == _curves.Length)
                {
                    _returning = true;
                }
            } else
            {
                _curveIndex--;
                if (_curveIndex == -1)
                {
                    _returning = false;
                }
            }
        }
    }
}
