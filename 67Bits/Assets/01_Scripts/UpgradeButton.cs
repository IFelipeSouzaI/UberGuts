using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI goldLabel;
    [SerializeField] private int baseCost = 1;
    [SerializeField] private int multCostPerLevel = 2;

    private int currentCost = 0;

    private void Start() {
        GameEvents.current.OnGameInfoLoaded += GoldLabelUpdate;
    }

    public void UpgradeRequest() {
        if(GameManager.Instance.CurrentMoney >= currentCost) {
            GameManager.Instance.PileLevel += 1;
            GameManager.Instance.CurrentMoney -= currentCost;
            GameManager.Instance.MaxPileSize = GameManager.Instance.PileLevel + GameManager.Instance.MinPileSize;
            GameEvents.current.UpgradeComplete();
        }
    }

    private void GoldLabelUpdate() {
        currentCost = baseCost + ((GameManager.Instance.PileLevel) * multCostPerLevel);
        goldLabel.text = "Cost:\n" + currentCost + " Gold";
    }

}
