using UnityEngine;

public static class FVibrator
{
    # if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService","vibrator");
    #else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
    #endif

    public static void Vibrate(long miliseconds = 250) {
        if(IsAndroid()) {
            vibrator.Call("vibrate", miliseconds);
        } else {
            Handheld.Vibrate();
        }
    }

    public static void Cancel() {
        if(IsAndroid()) {
            vibrator.Call("cancel");
        }
    }

    public static bool IsAndroid() {
        #if UNITY_ANDROID && !UNITY_EDITOR
        return true;
        #else
        return false;
        #endif
    }

}

public class Vibrator :MonoBehaviour
{

    //public SO_VibratorProfiles vibratorProfiles;

    private void Start() {
        GameEvents.current.OnLevelFail += Fail;
        GameEvents.current.OnLevelWin += Win;
        GameEvents.current.OnUpdateVibratorState += UpdateVibratorState;
    }

    private void UpdateVibratorState() {
        GameManager.Instance.CanVibrate = !GameManager.Instance.CanVibrate;
    }

    private void Fail() {
        if(!GameManager.Instance.CanVibrate) {
            return;
        }
        FVibrator.Vibrate(500);
    }

    private void Win() {
        if(!GameManager.Instance.CanVibrate) {
            return;
        }
        FVibrator.Vibrate(180);
    }

}
