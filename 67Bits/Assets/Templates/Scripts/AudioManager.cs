using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{  
    public List<SO_Sound> sfx = new List<SO_Sound>();
    public AudioSource music;
    void Awake(){
        for(int i = 0; i < sfx.Count; i++){
            sfx[i].source = gameObject.AddComponent<AudioSource>();
            sfx[i].source.clip = sfx[i].clip;
            sfx[i].source.volume = sfx[i].volume;
            sfx[i].source.pitch = sfx[i].pitch;
            sfx[i].source.loop = sfx[i].loop;
        }
    }

    private void Start() {
        AudioEvents.current.OnUpdateMusicState += MusicOnOff;
        AudioEvents.current.OnUpdateSfxState += SfxOnOff;
        AudioEvents.current.OnPlaySound += Play;
    }

    private void Play(string name){
        int indexToPlay = -1;
        if(GameManager.Instance.CanPlaySFX){
            for(int i = 0; i < sfx.Count; i++){
                if(sfx[i].name == name){
                    indexToPlay = i;
                    break;
                }
            }
            if(indexToPlay == -1){
                Debug.LogError("Erro: Sfx do not exist");
                return;
            }
            sfx[indexToPlay].source.Play();
        }
    }

    public void UpdateMusicState(){
        if(GameManager.Instance.CanPlayMusic){
            music.Play();
            return;
        }
        music.Stop();
    }

    public void SfxOnOff(){
        GameManager.Instance.CanPlaySFX = !GameManager.Instance.CanPlaySFX;
    }
    public void MusicOnOff(){
        GameManager.Instance.CanPlayMusic = !GameManager.Instance.CanPlayMusic;
        UpdateMusicState();
    }

}
