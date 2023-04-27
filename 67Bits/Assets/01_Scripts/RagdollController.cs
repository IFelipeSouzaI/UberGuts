using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    
    public List<Rigidbody> ragRigidbody = new List<Rigidbody>();
    public List<Collider> ragCollider = new List<Collider>();

    private void Start() {
        SetRagState(false);
    }

    public void SetRagState(bool state) {
        for(int i = 0; i < ragRigidbody.Count;i++) {
            ragRigidbody[i].isKinematic = !state;
            ragCollider[i].enabled = state;
        }
    }

    public void ApplyForce(Vector3 dir, Vector2 throwForceRange) {
        for(int i = 0; i < ragRigidbody.Count;i++) {
            ragRigidbody[i].AddForce(dir * Random.Range(throwForceRange.x, throwForceRange.y));
        }    
    }

}
