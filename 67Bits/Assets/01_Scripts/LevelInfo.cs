using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInfo : MonoBehaviour
{
    [Header("Level Info")]
    [SerializeField] private TextMeshProUGUI goldLabel;
    [SerializeField] private TextMeshProUGUI pileLabel;

    private void Start() {
        GameEvents.current.OnLevelLoaded += ResetEnemyLabel;
        GameEvents.current.OnEnemyAddedToPile += UpdateEnemyLabel;
        GameEvents.current.OnUpgradeComplete += UpdateEnemyLabel;
        GameEvents.current.OnUpgradeComplete += UpdateMoneyLabel;
        GameEvents.current.OnEnemiesToDarkHole += UpdateEnemyLabel;
        GameEvents.current.OnEnemiesToDarkHole += UpdateMoneyLabel;
    }

    private void UpdateEnemyLabel() {
        pileLabel.text = "Enemies: " + GameManager.Instance.CurrentPileSize + "/" + GameManager.Instance.MaxPileSize;
    }

    private void ResetEnemyLabel() {
        GameManager.Instance.CurrentPileSize = 0;
        pileLabel.text = "Enemies: " + GameManager.Instance.CurrentPileSize + "/" + GameManager.Instance.MaxPileSize;
    }

    private void UpdateMoneyLabel() {
        goldLabel.text = "Gold: " + GameManager.Instance.CurrentMoney;
    }

}
