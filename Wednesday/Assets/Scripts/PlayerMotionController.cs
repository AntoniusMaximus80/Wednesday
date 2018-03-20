using UnityEngine;

public class PlayerMotionController : MonoBehaviour {

    public float _movementMultiplier,
        _jumpInitialVelocity;
    public float _gravity = 9.81f;
    private Vector3 _movementVector;
    private CharacterController _characterController;

    void Start() {
        _characterController = GetComponent<CharacterController>();
        _movementVector = Vector3.zero;
    }

    void Update() {
        if (_characterController.isGrounded) // The player shouldn't be able to change it's direction while jumping.
        {
            _movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            _movementVector *= Time.deltaTime * _movementMultiplier;

            if (Input.GetKey(KeyCode.Space))
                _movementVector.y += _jumpInitialVelocity;
        } else
        {
            _movementVector.y -= _gravity * Time.deltaTime;
        }

        _characterController.Move(_movementVector * Time.deltaTime * _movementMultiplier);

        Vector3 lookRotation = _movementVector;
        lookRotation.y = 0f;

        if (lookRotation.x != 0 || lookRotation.z != 0)
            transform.rotation = Quaternion.LookRotation(lookRotation * Time.deltaTime);
    }
}
