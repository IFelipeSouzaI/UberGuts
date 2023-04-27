using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIElements : MonoBehaviour
{
    
    [Header("Level Info")]
    [SerializeField]
    private TextMeshProUGUI levelLabel;
    [SerializeField]
    private Animator winScreen;
    [SerializeField]
    private Animator loseScreen;


    [Header("FadeOptions")]
    [SerializeField]
    private float fadeSpeed = 2f;
    [SerializeField]
    private Image fadeImage;

    private bool initialFadeState = true;
    private int fadeValue = 0;

    [Header("Tutorial Info")]
    [SerializeField]
    private GameObject tutorialContainer;
    [SerializeField]
    public List<SO_Tutorial> tutorials = new List<SO_Tutorial>();
    [SerializeField]
    private TextMeshProUGUI tutorialText;
    [SerializeField]
    private Animator tutorialAnim;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject pauseMenu;

    private void Start() {
        fadeImage.enabled = initialFadeState;
        tutorialText.text = tutorials[0].label;
        GameEvents.current.OnLevelLoaded += LevelLabelUpdate;
        GameEvents.current.OnStartFadeIn += StartFadeIn;
        GameEvents.current.OnStartFadeOut += StartFadeOut;
        GameEvents.current.OnShowTutorial += ShowTutorial;
        GameEvents.current.OnHideTutorial += HideTutorial;
        GameEvents.current.OnLevelWin += ShowWinScreen;
        GameEvents.current.OnNextLevel += HideWinScreen;
        GameEvents.current.OnLevelFail += ShowLoseScreen;
        GameEvents.current.OnReloadLevel += HideLoseScreen;
    }

    void Update(){
        if(fadeValue == 0) {
            return;
        }
        if (fadeValue == -1){
            DecreaseAlpha();
        } else if (fadeValue == 1){
            IncreaseAlpha();
        }
    }

    // --- FADE

    private void DecreaseAlpha(){
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Max(0, fadeImage.color.a - fadeSpeed * Time.deltaTime));
        if (fadeImage.color.a <= 0){
            fadeValue = 0;
            GameEvents.current.FadeOutComplete();
            fadeImage.enabled = false;
        }
    }

    private void IncreaseAlpha(){
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Min(1, fadeImage.color.a + fadeSpeed * Time.deltaTime));
        if (fadeImage.color.a >= 1){
            fadeValue = 0;
            GameEvents.current.FadeInComplete();
        }
    }

    private void StartFadeIn() {
        fadeValue = 1;
        fadeImage.enabled = true;
    }

    private void StartFadeOut() {
        fadeValue = -1;
    }

    // ---

    // --- Tutorial

    private void ShowTutorial(int tutorialIndex) {
        tutorialContainer.SetActive(true);
        tutorialText.text = tutorials[tutorialIndex].label;
        tutorialAnim.SetBool(tutorials[tutorialIndex].animTrigger, true);
    }

    private void HideTutorial() {
        tutorialContainer.SetActive(false);
    }

    // ---


    // --- Level Options

    private void LevelLabelUpdate() {
        levelLabel.gameObject.SetActive(true);
        pauseButton.SetActive(true);
        levelLabel.text = "Level " + (GameManager.Instance.CurrentLevel+1);
    }

    private void ShowWinScreen() {
        levelLabel.gameObject.SetActive(false);
        pauseButton.SetActive(false);
        winScreen.SetTrigger("in");
    }

    private void HideWinScreen() {
        winScreen.SetTrigger("out");
    }

    private void ShowLoseScreen() {
        levelLabel.gameObject.SetActive(false);
        pauseButton.SetActive(false);
        loseScreen.SetTrigger("in");
    }

    private void HideLoseScreen() {
        loseScreen.SetTrigger("out");
    }

    // ---

}