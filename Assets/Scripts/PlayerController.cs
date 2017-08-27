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
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= speed;

        _rb.AddForce(_moveDirection * Time.deltaTime, ForceMode.VelocityChange);
        _rb.AddForce(_grav.gravity * Time.deltaTime, ForceMode.Acceleration);
    }
}
