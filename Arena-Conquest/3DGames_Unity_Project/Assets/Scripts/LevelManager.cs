using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void EnemyDied(GameObject gameObject);
public class LevelManager : MonoBehaviour
{
    public AudioClip[] AudioClips;
    public int currentTrackIndex;
    AudioSource Source;
    public static event EnemyDied OnEnemyDied;
    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Source.isPlaying)
            UpdateSourceAndPlay();

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
