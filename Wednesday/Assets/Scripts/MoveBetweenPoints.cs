using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour {

    [SerializeField]
    private Line[] _line;

    [SerializeField]
    private GameObject _cubePrefab;

    private GameObject _instantiatedCube;

    private Vector3 _startingPosition,
        _endPosition;

    public float _duration;

    private float _startTime;

    //private float _distance;

    private int _lineIndex = 0;

    private bool _returning = false;

    // Use this for initialization
    void Start()
    {
        _startTime = Time.time;
        _startingPosition = _line[_lineIndex].vStart;
        _endPosition = _line[_lineIndex].vEnd;
        _instantiatedCube = Instantiate(_cubePrefab, _line[0].vStart, new Quaternion(0f, 0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        // Update path in real-time.
        /*if (!_returning) {
            _startingPosition = _line[_lineIndex].vStart;
            _endPosition = _line[_lineIndex].vEnd;
        } else
        {
            _startingPosition = _line[_lineIndex].vEnd;
            _endPosition = _line[_lineIndex].vStart;
        }*/

        float ratio = (Time.time - _startTime) / _duration;
        _instantiatedCube.transform.position = Vector3.Lerp(_startingPosition, _endPosition, ratio);

        if (ratio >= 1f)
        {
            _startTime = Time.time;
            if (!_returning)
            {
                _lineIndex++;
                if (_lineIndex != _line.Length)
                {
                    _startingPosition = _line[_lineIndex].vStart;
                    _endPosition = _line[_lineIndex].vEnd;
                } else
                {
                    _lineIndex--;
                    _startingPosition = _line[_lineIndex].vEnd;
                    _endPosition = _line[_lineIndex].vStart;
                    _returning = true;
                }
            } else
            {
                _lineIndex--;
                if (_lineIndex != -1)
                {
                    _startingPosition = _line[_lineIndex].vEnd;
                    _endPosition = _line[_lineIndex].vStart;
                } else
                {
                    _lineIndex++;
                    _startingPosition = _line[_lineIndex].vStart;
                    _endPosition = _line[_lineIndex].vEnd;
                    _returning = false;
                }
            }

        }
    }
}
