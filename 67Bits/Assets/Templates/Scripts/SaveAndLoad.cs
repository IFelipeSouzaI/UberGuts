using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    private void Start(){
        GameEvents.current.OnSaveGame += SaveGame;
        Invoke("LoadGame", 0.5f);
    }

    private void LoadGame() {
        GameManager.Instance.CurrentLevel = PlayerPrefs.GetInt("currentLevel", 0);
        GameManager.Instance.PileLevel = PlayerPrefs.GetInt("pileLevel", 0);
        GameManager.Instance.CurrentMoney = PlayerPrefs.GetInt("currentMoney", 0);
        GameManager.Instance.MaxPileSize = GameManager.Instance.MinPileSize + GameManager.Instance.PileLevel;
        GameEvents.current.GameInfoLoaded();
        GameEvents.current.FadeOut();
    }
 
    private void SaveGame() {
        PlayerPrefs.SetInt("currentLevel", GameManager.Instance.CurrentLevel);
        PlayerPrefs.SetInt("pileLevel", GameManager.Instance.PileLevel);
        PlayerPrefs.SetInt("currentMoney", GameManager.Instance.CurrentMoney);
        PlayerPrefs.Save();
    }
}
