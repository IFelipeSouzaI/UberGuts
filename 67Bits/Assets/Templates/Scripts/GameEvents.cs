using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    
    public static GameEvents current;

    private void Awake() {
        current = this;
    }

    // TO ADD: EventsManager.current.onEVENTNAME += AddTarget;
    // TO CALL: EventsManager.current.EVENTFUNCTION();

    public event Action OnButtonClick; // Button Click
    public void ButtonClick() {
        if(OnButtonClick != null) {
            OnButtonClick();
        }
    }

    public event Action OnShowIntersticial; // Show Instersticial
    public void ShowInstersticial() {
        if(OnShowIntersticial != null) {
            OnShowIntersticial();
        }
    }

    public event Action OnGameInfoLoaded; // Save Loaded
    public void GameInfoLoaded() {
        if(OnGameInfoLoaded != null) {
            OnGameInfoLoaded();
        }
    }

    public event Action OnSaveGame; // To Save the Game
    public void SaveGame() {
        if(OnSaveGame != null) {
            OnSaveGame();
        }
    }

    public event Action OnLevelLoaded; // Level Prefab was Loaded
    public void LevelLoaded() {
        if(OnLevelLoaded != null) {
            OnLevelLoaded();
        }
    }

    public event Action OnReloadLevel; // To Reload the Level
    public void ReloadLevel() {
        if(OnReloadLevel != null) {
            OnReloadLevel();
        }
    }

    public event Action OnNextLevel; // To Load Next Level
    public void NextLevel() {
        if(OnNextLevel != null) {
            OnNextLevel();
        }
    }

    public event Action OnPauseLevel; // To Pause/Resume
    public void PauseLevel() {
        if(OnPauseLevel != null) {
            OnPauseLevel();
        }
    }

    public event Action<int> OnShowTutorial; // Show Tutorial
    public void ShowTutorial(int tutorialIndex = 0) {
        if(OnShowTutorial != null) {
            OnShowTutorial(tutorialIndex);
        }
    }

    public event Action OnHideTutorial; // Hide Tutorial
    public void HideTutorial() {
        if(OnHideTutorial != null) {
            OnHideTutorial();
        }
    }

    public event Action OnLevelWin; // The level was won
    public void LevelWin() {
        if(OnLevelWin != null) {
            OnLevelWin();
        }
    }

    public event Action OnLevelFail; // The level fail
    public void LevelFail() {
        if(OnLevelFail != null) {
            OnLevelFail();
        }
    }

    public event Action OnStartFadeIn; // Start the fade in
    public void FadeIn() {
        if(OnStartFadeIn != null) {
            OnStartFadeIn();
        }
    }
    public event Action OnFadeInComplete; // Fade in Completed
    public void FadeInComplete() {
        if(OnFadeInComplete != null) {
            OnFadeInComplete();
        }
    }
    public event Action OnStartFadeOut; // Start the fade out
    public void FadeOut() {
        if(OnStartFadeOut != null) {
            OnStartFadeOut();
        }
    }
    public event Action OnFadeOutComplete; // Fade out complete
    public void FadeOutComplete() {
        if(OnFadeOutComplete != null) {
            OnFadeOutComplete();
        }
    }

    public event Action OnUpdateVibratorState;
    public void UpdateVibratorState(){
        if(OnUpdateVibratorState != null){
            OnUpdateVibratorState();
        }
    }

    // -- IN GAME

    public event Action<EnemyBodyCollision> OnAddEnemyToPile;
    public void AddEnemyToPile(EnemyBodyCollision enemy){
        if(OnAddEnemyToPile != null){
            OnAddEnemyToPile(enemy);
        }
    }

    public event Action OnEnemyAddedToPile;
    public void EnemyAddedToPile(){
        if(OnEnemyAddedToPile != null){
            OnEnemyAddedToPile();
        }
    }

    public event Action OnEnemyPunched;
    public void EnemyPunched(){
        if(OnEnemyPunched != null){
            OnEnemyPunched();
        }
    }

    public event Action OnEnemiesToDarkHole;
    public void EnemiesToDarkHole(){
        if(OnEnemiesToDarkHole != null){
            OnEnemiesToDarkHole();
        }
    }

    public event Action<int> OnEnemiesDeath;
    public void EnemiesDeath(int amount){
        if(OnEnemiesDeath != null){
            OnEnemiesDeath(amount);
        }
    }

    public event Action OnUpgradeComplete;
    public void UpgradeComplete(){
        if(OnUpgradeComplete != null){
            OnUpgradeComplete();
        }
    }

}
