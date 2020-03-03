using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class MusicController : Singleton<MusicController>
{
    public AudioSource[] musicTracks;
    public float DelayBetweenSongs = 10f;

    private int currentTrack = 0;

    private void Awake()
    {
        
    }

    public void StartMusic()
    {
        StartCoroutine(PlayTrack(DelayBetweenSongs));
    }

    private IEnumerator PlayTrack(float delay)
    {
        musicTracks[currentTrack].Play();

        yield return new WaitForSeconds(musicTracks[currentTrack].clip.length + delay);

        PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        StopAllCoroutines();

        if (currentTrack >= musicTracks.Length - 1)
        {
            currentTrack = 0;
        }
        else
        {
            currentTrack++;
        }

        StartCoroutine(PlayTrack(DelayBetweenSongs));
    }
}
