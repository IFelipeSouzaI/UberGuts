using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputsManager : MonoBehaviour
{
    
    private bool hasTutorial = false;

    private Vector2 firstTouchPos;
    private Vector2 lastTouchPos;

    private void Start() {
        GameEvents.current.OnShowTutorial += HasTutorial;
        GameEvents.current.OnLevelLoaded += ShowTutorial;
    }

    private void ShowTutorial() {
        GameEvents.current.ShowTutorial(0);
    }

    private void HasTutorial(int value = 0) {
        hasTutorial = true;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)) {
            if(CheckUITouch()) {
                return;
            }
            firstTouchPos = Input.mousePosition;
            if(hasTutorial) {
                GameEvents.current.HideTutorial();
                hasTutorial = false;
            }
        }
        if(Input.GetMouseButtonUp(0)) {
            lastTouchPos = Input.mousePosition;
            if(Vector2.Distance(firstTouchPos, lastTouchPos) > 50f) {
                if(lastTouchPos.x > firstTouchPos.x) {
                    InputEvents.current.SwipeRight();
                }else{
                    InputEvents.current.SwipeLeft();    
                }
            }
        }
    }

    private bool CheckUITouch() {
		if(EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.tag == "Button") {
			return true;
        }
		return false;
    }

}
