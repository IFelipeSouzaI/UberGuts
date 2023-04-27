using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventsPlayer : MonoBehaviour
{
    void Start(){
        GameEvents.current.OnLevelWin += Win;    
        GameEvents.current.OnLevelFail += Fail;
        GameEvents.current.OnButtonClick += Click;
    }

    private void Win() {
        AudioEvents.current.PlaySound("LevelWin");
    }
    private void Fail() {
        AudioEvents.current.PlaySound("LevelFail");
    }
    private void Click() {
        AudioEvents.current.PlaySound("Button");
    }

}
