using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONeillObject : MonoBehaviour {

    private ONeillGravity _source;

    public Vector3 up { get { return _source.GetUp(transform.position); } }
    public Vector3 gravity { get { return _source == null ? Vector3.zero : _source.GetGravity(transform.position); } }

    void Start() {
        _source = ONeillGravity.instance;
    }
}
