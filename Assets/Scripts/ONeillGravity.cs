using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONeillGravity : MonoBehaviour {

    public static ONeillGravity instance { get; private set; }

    public Vector3 affectedAxes;
    public float gravity;

    void Awake() {
        if (instance != null)
            throw new System.Exception();

        instance = this;
    }
    
    public Vector3 GetUp(Vector3 position) {
        return MaskAxes(transform.position - position).normalized;
    }

    public Vector3 GetGravity(Vector3 position) {
        return MaskAxes(transform.position - position) * -gravity;
    }

    private Vector3 MaskAxes(Vector3 vector) {
        vector.x *= affectedAxes.x;
        vector.y *= affectedAxes.y;
        vector.z *= affectedAxes.z;
        return vector;
    }
}
