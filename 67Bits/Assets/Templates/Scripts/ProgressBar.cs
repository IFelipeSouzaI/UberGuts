using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    
    [SerializeField]
    private float maxValue = 5f;
    [SerializeField]
    private float fillSpeed = 1f;
    [SerializeField]
    private Image fill;
    private float currentFill = 0;
    private bool canUpdate = false;

    private void Update() {
        if(!canUpdate) {
            return;
        }
        if(fill.fillAmount < currentFill) {
            fill.fillAmount += Time.deltaTime * fillSpeed;
            if(fill.fillAmount > currentFill) {
                fill.fillAmount = currentFill;
                canUpdate = false;
            }
        }
    }

    [ContextMenu("Update Bar")]
    private void FillUpdate() {
        currentFill += 1f/maxValue;
        Debug.Log(currentFill);
        canUpdate = true;
    }
    [ContextMenu("Reset Bar")]
    private void ResetBar() {
        currentFill = 0;
        fill.fillAmount = 0;
        canUpdate = false;
    }

}
