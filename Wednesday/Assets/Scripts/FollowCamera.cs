using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject _player;
    private Transform _followCameraPreviousTransform;
    private Vector3 _newCameraPosition;
    public float _cameraDistance,
        _cameraHeight,
        _slerpDelay;
    LayerMask _obstaclesMask,
        _slopesMask;

	// Use this for initialization
	void Start () {
        _followCameraPreviousTransform = transform;
        _obstaclesMask = LayerMask.GetMask("Obstacles");
        _slopesMask = LayerMask.GetMask("Slopes");
    }

    // Update is called once per frame
    void Update () {
        _newCameraPosition = _player.transform.position - (_player.transform.forward * _cameraDistance) + new Vector3(0f, _cameraHeight, 0f); // Calculate the new camera position.

        Ray _ray = new Ray(_player.transform.position, -_player.transform.forward);
        Debug.DrawRay(_player.transform.position, -_player.transform.forward);
        RaycastHit _raycastHit;

        if (Physics.Raycast(_ray, out _raycastHit, Vector3.Distance(_player.transform.position, _newCameraPosition), _slopesMask)) { // Check if the raycast hits a slope.
            //Debug.Log("Slope hit!");
            Debug.DrawLine(_player.transform.position, _raycastHit.point, Color.red);
            _newCameraPosition = _raycastHit.point + // Move the camera to the raycast hit point.
                (_player.transform.forward * 0.25f) + // Move the camera towards the player.
                new Vector3(0f, _cameraHeight, 0f); // Move the camera upwards, so it doesn't enter the ramp.
        } else if (Physics.Raycast(_ray, out _raycastHit, Vector3.Distance(_player.transform.position, _newCameraPosition), _obstaclesMask)) // If not, check if the raycast hits other obstacles.
        {
            Debug.DrawLine(_player.transform.position, _raycastHit.transform.position, Color.red);
            _newCameraPosition = _raycastHit.point + // Move the camera to the raycast hit point.
                (_player.transform.forward * 0.25f); // Move the camera towards the player.
        }

        Debug.DrawLine(_player.transform.position, _newCameraPosition, Color.green);

        transform.position = Vector3.Slerp(_followCameraPreviousTransform.position,
            _newCameraPosition,
            _slerpDelay * Time.deltaTime);

        transform.LookAt(_player.transform); // Make the camera look at the player.

        _followCameraPreviousTransform = transform; // Store the current camera position for slerp.
    }
}
