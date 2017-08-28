using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float lookSensitivity;

    private Rigidbody _rb;
    private Transform _cameraTransform;
    private Vector3 _moveDirection = Vector3.zero;
    private ONeillObject _grav;
    private float xRot = 0;

    private bool _grounded;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        _cameraTransform = GetComponentInChildren<Camera>().transform;
        _grav = GetComponent<ONeillObject>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        xRot += Input.GetAxis("Mouse X") * lookSensitivity;

        transform.up = _grav.up;
        transform.Rotate(_grav.up, xRot, Space.World); 
        _cameraTransform.Rotate(-Input.GetAxis("Mouse Y") * lookSensitivity, 0, 0);
    }

    void FixedUpdate() {
        if (_grounded) {
            var moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        
            _rb.velocity = moveDirection;
        }
        
        _rb.velocity += _grav.gravity * Time.deltaTime;

        _grounded = false;
    }

    void OnCollisionStay(Collision collision) {
        _grounded = true;        
    }
}
