using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject _player;
    private Transform _followCameraPreviousTransform;
    private Vector3 _newCameraPosition;
    private Ray _sphereCastRay;
    public float _cameraDistance,
        _slerpDelay;

	// Use this for initialization
	void Start () {
        _followCameraPreviousTransform = transform;
    }

    /*  RaycastHit hit;

        Vector3 p1 = transform.position + charCtrl.center;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, charCtrl.height / 2, transform.forward, out hit, 10))
        {
            distanceToObstacle = hit.distance;
        }*/

    // Update is called once per frame
    void Update () {
        _newCameraPosition = _player.transform.position - (_player.transform.forward * _cameraDistance) + new Vector3(0f, 4f, 0f); // Calculate the new camera position.

        /*Ray _ray = new Ray(_player.transform.position, _newCameraPosition);
        RaycastHit _raycastHit;

        if (Physics.SphereCast(_ray, 1f, out _raycastHit, 5f, 8))
        {
            _newCameraPosition += _player.transform.forward * 0.5f;
            Debug.DrawLine(_player.transform.position, _newCameraPosition, Color.red);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_newCameraPosition, new Vector3(1f, 1f, 1f));
        } else
        {
            Debug.DrawLine(_player.transform.position, _newCameraPosition, Color.green);

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_newCameraPosition, new Vector3(1f, 1f, 1f));
        }*/

        transform.position = Vector3.Slerp(_followCameraPreviousTransform.position,
            _newCameraPosition,
            _slerpDelay * Time.deltaTime);

        transform.LookAt(_player.transform); // Make the camera look at the player.

        _followCameraPreviousTransform = transform; // Store the current camera position for slerp.

        //GetComponent<Camera>().
    }
}
