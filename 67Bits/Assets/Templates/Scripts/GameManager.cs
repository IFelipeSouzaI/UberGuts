using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
  
    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    
    public int CurrentPileSize { get; set; } = 0;
    public int MaxPileSize { get; set; } = 0;
    public int MinPileSize { get; set; } = 5;
    // To Save
    public int CurrentLevel { get; set; } = 1;
    public int PileLevel { get; set; } = 0;
    public int CurrentMoney { get; set; } = 0;
    // --

    // -- Running
    public bool CanPlaySFX { get; set; } = true;
    public bool CanPlayMusic { get; set; } = true;
    public bool CanVibrate { get; set; } = true;
    public bool IsPaused { get; set; } = false;

    public float JoySpeed { get; set; } = 0f;
    public Vector2 JoyVector { get; set; } = Vector2.zero;

    // --

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}