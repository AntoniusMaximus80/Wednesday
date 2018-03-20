using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    public GameObject _player;
    public float _cameraHeight;
	
	void Update () {
        Vector3 playerPosition = _player.transform.position;
        playerPosition.y = _cameraHeight;
        transform.position = playerPosition;
    }
}
