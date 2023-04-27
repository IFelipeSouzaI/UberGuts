using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite pressed;
    [SerializeField]
    private Image buttonImage;

    [SerializeField]
    private Sprite vibratorNormal;
    [SerializeField]
    private Sprite vibratorPressed;
    [SerializeField]
    private Image vibratorButtonImage;

    public void SetPause() {
        GameManager.Instance.IsPaused = !GameManager.Instance.IsPaused;
        GameEvents.current.PauseLevel();
        if(GameManager.Instance.IsPaused){
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1;
            GameEvents.current.ShowInstersticial();
            pauseMenu.SetActive(false);
        }
    }

    public void SetSFX() {
        AudioEvents.current.UpdateSfxState();
        if(GameManager.Instance.CanPlaySFX) {
            buttonImage.sprite = normal;
        } else {
            buttonImage.sprite = pressed;
        }
    }

    public void SetVibrator() {
        GameEvents.current.UpdateVibratorState();
        if(GameManager.Instance.CanVibrate) {
            vibratorButtonImage.sprite = vibratorNormal;
        } else {
            vibratorButtonImage.sprite = vibratorPressed;
        }
    }

}
