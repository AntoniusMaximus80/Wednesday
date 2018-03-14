using UnityEngine;

public class MainCamera : MonoBehaviour {

    public GameObject _player;
    private Vector3 _playerCurrentPosition;

	// Use this for initialization
	void Start () {
        _playerCurrentPosition = _player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        _playerCurrentPosition = _player.transform.position;
        transform.position = _playerCurrentPosition + new Vector3(6f, 32f, -42f);
	}
}
