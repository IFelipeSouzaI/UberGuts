using System;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{

    public static AudioEvents current;

    private void Awake() {
        current = this;
    }

    public event Action OnUpdateSfxState;
    public void UpdateSfxState(){
        if(OnUpdateSfxState != null){
            OnUpdateSfxState();
        }
    }

    public event Action OnUpdateMusicState;
    public void UpdateMusicState(){
        if(OnUpdateMusicState != null){
            OnUpdateMusicState();
        }
    }

    public event Action<string> OnPlaySound;
    public void PlaySound(string soundString){
        if(OnPlaySound != null){
            OnPlaySound(soundString);
        }
    }
}
