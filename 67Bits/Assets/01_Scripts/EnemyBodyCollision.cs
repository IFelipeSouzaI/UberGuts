using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyCollision : MonoBehaviour
{
    [Header("Object Options")]
    [SerializeField] private Transform father;
    [Header("Layer Options")]
    [SerializeField] private string mainLayer;
    [SerializeField] private string toBeCollectedLayer;
    [Header("Ragdoll Options")]
    [SerializeField] private Collider bodyCollider;
    [SerializeField] private RagdollController myRagdoll;
    [SerializeField] private Vector2 throwForceRange = Vector2.zero; 
    [SerializeField] private Animator anim;

    public void ThrowAway(Vector3 throwDir) {
        anim.enabled = false;
        bodyCollider.enabled = false;
        Invoke("UpdateBodyState",1f);
        myRagdoll.SetRagState(true);
        myRagdoll.ApplyForce(throwDir, throwForceRange*10f);
    }

    public void SetPileInfo(Vector3 newLocalPos, Transform newParent, int pileIndex) {
        myRagdoll.SetRagState(false);
        anim.enabled = true;
        anim.SetBool("isPile", true);
        
        bodyCollider.enabled = false;
        //father.parent = newParent;
        father.position = newLocalPos;
        //father.localRotation = Quaternion.Euler(new Vector3(0,180*(pileIndex%2),0));
        //father.parent = null;
        /// 90*(1-(2*(pileIndex%2)))
    }

    private void UpdateBodyState() {
        bodyCollider.enabled = true;
        this.gameObject.layer = LayerMask.NameToLayer(toBeCollectedLayer);
    }

    public Transform GetFather() {
        return father;
    }

}
