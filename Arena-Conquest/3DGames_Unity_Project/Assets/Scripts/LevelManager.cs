using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState
{
    Started,
    Playing,
    Paused,
    GameOver
}

public delegate void EnemyDied(GameObject gameObject);
public class LevelManager : MonoBehaviour
{
    public static GameState currentGameState;

    public AudioClip[] AudioClips;
    public Transform playerSpawnPosition;
    public bool MusicOn;
    public GameObject Player;
    public GameObject startedPanel;
    public GameObject pausedPanel;
    public GameObject PlayerHUD;

    int currentTrackIndex;
    AudioSource Source;
    bool paused = false;
    public static event EnemyDied OnEnemyDied;
    private void Start()
    {
        Source = GetComponent<AudioSource>();
        // for now start puased
        PlayerHUD.SetActive(false);
        Pause();
        Player.transform.position = playerSpawnPosition.position;
    }

    private void Update()
    {
        if (MusicOn)
        {
            if (!Source.isPlaying || Source.clip == null)
                UpdateSourceAndPlay();
        }

        switch (currentGameState)
        {
            case GameState.Started:
                // show help UI
                if (Input.anyKey)
                {
                    Pause();
                    currentGameState = GameState.Playing;
                    startedPanel.SetActive(false);
                    PlayerHUD.SetActive(true);
                }
                break;
            case GameState.Playing:
                if(Input.GetKeyUp(KeyCode.Escape))
                {
                    Pause();
                    pausedPanel.SetActive(paused);
                    PlayerHUD.SetActive(!paused);
                }
                break;
            case GameState.GameOver:
                // play something or do nothing and show retry or exit ui 
                break;
        }

    }

    private void Pause()
    {
        // stop time
        paused = !paused;
        Time.timeScale = paused ? 0 :1;
        // show or hide ui

    }

    private void UpdateSourceAndPlay()
    {
        Source.clip = AudioClips[currentTrackIndex];
        Source.Play();
        currentTrackIndex++;
        if (currentTrackIndex >= AudioClips.Length) currentTrackIndex = 0;
    }

    public static void IDied(GameObject gameObject)
    {
        OnEnemyDied?.Invoke(gameObject);
    }
}
