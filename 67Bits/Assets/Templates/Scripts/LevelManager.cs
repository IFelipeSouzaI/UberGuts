using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Threading;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelSet = new List<GameObject>();

    private GameObject currentLevel;

    private int levelState = 0;

    private void Start() {
        /*Thread backgroundThread = new Thread(LoadLevel);
        backgroundThread.Start();*/
        GameEvents.current.OnFadeInComplete += NewLevel;

        GameEvents.current.OnGameInfoLoaded += LoadLevel;

        GameEvents.current.OnNextLevel += NextLevel;
        GameEvents.current.OnReloadLevel += ReloadLevel;
    }

    private void LoadLevel(){
        currentLevel = Instantiate(levelSet[GameManager.Instance.CurrentLevel%levelSet.Count], transform.position, Quaternion.identity);
        GameEvents.current.LevelLoaded();
    }

    private void NextLevel() {
        GameManager.Instance.CurrentLevel += 1;
        Destroy(currentLevel);
        GameEvents.current.SaveGame();
        levelState = 1;
        GameEvents.current.FadeIn();
    }

    private void ReloadLevel() {
        Destroy(currentLevel);
        GameEvents.current.SaveGame();
        levelState = 1;
        GameEvents.current.FadeIn();
    }

    private void NewLevel() {
        if(levelState == 0) {
            return;
        }
        LoadLevel();
        GameEvents.current.FadeOut();
        levelState = 0;
    }

}
