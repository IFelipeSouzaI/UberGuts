using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    private bool isLocked = false;
	private int eventIndex = 0;

	// Radius based on Joystick Object Size
	public float RADIUS = 64;
	public float SMALL_RADIUS = 32;

	private Vector3 stickPos;
	
	[Header("Object Reference")]
	public GameObject joy;
	public RectTransform canvas;

	private float width;
	private float height;

	private void Awake(){
		width = Screen.width;
        height = Screen.height;
		stickPos = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
		stickPos = new Vector3(Map(stickPos.x, 0, canvas.sizeDelta.x, 0, width), Map(stickPos.y, 0, canvas.sizeDelta.y, 0, height), stickPos.z);
	}

    void Update(){
		if (isLocked){
			return;
		}
        if (Input.GetMouseButtonDown(0)){
            if(CheckUITouch()) {
				return;
            }
			stickPos = new Vector3(Map(Input.mousePosition.x, 0, width, 0, canvas.sizeDelta.x), Map(Input.mousePosition.y, 0, height, 0, canvas.sizeDelta.y), stickPos.z);
			this.gameObject.GetComponent<RectTransform>().anchoredPosition = stickPos;
			this.gameObject.GetComponent<Image>().enabled = true;
			joy.SetActive(true);
			InputEvents.current.JoyStarted();
			eventIndex = 1;
        }
        if (Input.GetMouseButton(0)){
            if (eventIndex == 1){
				stickPos = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
				stickPos = new Vector3(Map(stickPos.x, 0, canvas.sizeDelta.x, 0, width), Map(stickPos.y, 0, canvas.sizeDelta.y, 0, height), stickPos.z);
				float dist = Vector2.Distance(Input.mousePosition, stickPos);
				if((dist + SMALL_RADIUS) > RADIUS){
					dist = RADIUS - SMALL_RADIUS;
				}
				Vector2 vec = (Input.mousePosition - stickPos).normalized;
				joy.GetComponent<RectTransform>().anchoredPosition = dist*vec;
				GameManager.Instance.JoySpeed = dist/RADIUS;
				//joyAngle.Value = Vector3.Angle(joy.transform.position, transform.position);
				GameManager.Instance.JoyVector = vec;
			}
        }
        if (Input.GetMouseButtonUp(0)){
			this.gameObject.GetComponent<Image>().enabled = false;
			joy.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			joy.SetActive(false);
			//joySpeed.Value = 0;
			//joyAngle.Value = 0;
			GameManager.Instance.JoyVector = Vector2.zero;
			InputEvents.current.JoyFinished();
			eventIndex = -1;
        }
    }

	public void MovementLock(){
		this.gameObject.GetComponent<Image>().enabled = false;
		joy.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		joy.SetActive(false);
		GameManager.Instance.JoySpeed = 0f;
		//joyAngle.Value = 0;
		GameManager.Instance.JoyVector = Vector2.zero;
		isLocked = true;
	}

	public void MovementRelease(){
		isLocked = false;
	}

	private float Map(float s, float a1, float a2, float b1, float b2){
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

	private bool CheckUITouch() {
		if(EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.tag == "Button") {
			return true;
        }
		return false;
    }


}
