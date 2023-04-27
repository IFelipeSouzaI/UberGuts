using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEvents : MonoBehaviour
{
    [ContextMenu("Level Win")]
    private void LevelWin() {
        GameEvents.current.LevelWin();
    }
    [ContextMenu("Level Fail")]
    private void LevelFail() {
        GameEvents.current.LevelFail();
    }
    [ContextMenu("FadeIn")]
    private void FadeIn() {
        GameEvents.current.FadeIn();
    }
    [ContextMenu("FadeOut")]
    private void FadeOut() {
        GameEvents.current.FadeOut();
    }
    [ContextMenu("Next Level")]
    private void NextLevel() {
        GameEvents.current.NextLevel();
    }
    [ContextMenu("Reload Level")]
    private void ReloadLevel() {
        GameEvents.current.ReloadLevel();
    }
    [ContextMenu("Show Tutorial")]
    private void ShowTutorial() {
        GameEvents.current.ShowTutorial();
    }
    [ContextMenu("HideTutorial")]
    private void HideTutorial() {
        GameEvents.current.HideTutorial();
    }
}