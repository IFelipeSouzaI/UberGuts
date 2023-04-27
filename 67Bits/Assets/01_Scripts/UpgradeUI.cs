using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{

    [SerializeField] private GameObject upgradeButton;

    private void Start(){
        GameEvents.current.OnHideTutorial += HideElements;
        GameEvents.current.OnLevelLoaded += ShowElements;
    }
    
    private void ShowElements() {
        upgradeButton.SetActive(true);
    }

    private void HideElements() {
        upgradeButton.SetActive(false);
    }

}
