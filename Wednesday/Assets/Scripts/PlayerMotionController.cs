using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour {

    public float _movementMultiplier,
        _jumpInitialVelocity;
    private float _jumpVelocity = 0f;
    private bool _onGround = true;
    private CharacterController _characterController;

	// Use this for initialization
	void Start () {
        _characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Vector3 movementVector3 = new Vector3(xMovement, -9.81f, zMovement);

        if (_characterController.isGrounded && _jumpVelocity == 0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _jumpVelocity = _jumpInitialVelocity;
            }
        }

        if (_jumpVelocity > 0f)
        {
            _jumpVelocity -= Time.deltaTime * 4f;
            _jumpVelocity = Mathf.Clamp(_jumpVelocity, 0f, _jumpInitialVelocity);
            movementVector3.y += _jumpVelocity;
        }

        Move(movementVector3);

        Vector3 lookRotation = movementVector3;
        lookRotation.y = 0f;

        if (lookRotation.x != 0 || lookRotation.z != 0) {
            //Quaternion.Slerp();
            transform.rotation = Quaternion.LookRotation(lookRotation);
        }
    }

    private void Move(Vector3 movement)
    {
        _characterController.Move(movement * Time.deltaTime * _movementMultiplier);
    }

    private void Gravity()
    {

    }
}
