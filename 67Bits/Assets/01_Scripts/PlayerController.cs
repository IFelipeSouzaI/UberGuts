using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Options")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform camRef;
    [SerializeField] private Animator anim;
    private Vector3 finalPos;
    private bool canMove = false;

    private void Start() {
        InputEvents.current.OnJoyStarted += JoyStarted;
        InputEvents.current.OnJoyFinished += JoyFinished;
        GameEvents.current.OnEnemyPunched += Punch;
        GameEvents.current.OnLevelLoaded += PlayerReset;
    }

    private void Update() {
        if(!canMove) {
            return;
        }
        transform.LookAt(transform.position + new Vector3(GameManager.Instance.JoyVector.x, 0f, GameManager.Instance.JoyVector.y));
        finalPos = transform.localPosition + new Vector3(GameManager.Instance.JoyVector.x, 0f, GameManager.Instance.JoyVector.y) * GameManager.Instance.JoySpeed * Time.deltaTime * moveSpeed;
        transform.position = finalPos;
        camRef.position = finalPos;
    }

    private void JoyStarted() {
        canMove = true;
        anim.SetBool("isRunning", true);
    }

    private void JoyFinished() {
        canMove = false;
        anim.SetBool("isRunning", false);
    }

    private void Punch() {
        anim.SetTrigger("punch");
    }

    private void PlayerReset() {
        transform.position = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        camRef.position = transform.position;
    }

}
