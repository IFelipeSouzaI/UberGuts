using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProps : MonoBehaviour
{
    
    [SerializeField] private GameObject label;

    void Start(){
        GameEvents.current.OnHideTutorial += ShowLabel;
        GameEvents.current.OnReloadLevel += ShowLabel;
    }

    private void ShowLabel() {
        label.SetActive(true);
        GameEvents.current.OnHideTutorial-= ShowLabel;
        GameEvents.current.OnReloadLevel -= ShowLabel;
    }

    
}
