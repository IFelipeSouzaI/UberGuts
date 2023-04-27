using System;
using UnityEngine;

public class InputEvents : MonoBehaviour
{
    public static InputEvents current;

    private bool canCall = false;

    private void Awake() {
        current = this;
    }

    private void Start() {
        GameEvents.current.OnLevelLoaded += Unlock;
        GameEvents.current.OnLevelFail += Lock; 
        GameEvents.current.OnLevelWin += Lock;
    }

    private void Unlock() {
        canCall = true;
    }
    private void Lock() {
        canCall = false;
    }

    // TO ADD: EventsManager.current.onEVENTNAME += AddTarget;
    // TO CALL: EventsManager.current.EVENTFUNCTION();

    public event Action OnSwipeRight;
    public void SwipeRight() {
        if(OnSwipeRight != null && canCall) {
            OnSwipeRight();
        }
    }

    public event Action OnSwipeLeft;
    public void SwipeLeft() {
        if(OnSwipeLeft != null && canCall) {
            OnSwipeLeft();
        }
    }

    public event Action OnJoyStarted;
    public void JoyStarted() {
        if(OnJoyStarted != null && canCall) {
            OnJoyStarted();
        }
    }

    public event Action OnJoyFinished;
    public void JoyFinished() {
        if(OnJoyFinished != null) {
            OnJoyFinished();
        }
    }

}
