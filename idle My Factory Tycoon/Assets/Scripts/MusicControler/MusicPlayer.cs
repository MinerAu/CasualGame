using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    
    public List<AudioClip> musicTracks;
    public AudioMixerGroup musicMixerGroup;

    private AudioSource audioSource;
    private int currentTrackIndex = 0;

     private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = musicMixerGroup;
        StartCoroutine(PlayMusicTracks());
    }

    private IEnumerator PlayMusicTracks()
    {
        while (true)
        {
            if (currentTrackIndex < musicTracks.Count)
            {
                audioSource.clip = musicTracks[currentTrackIndex];
                audioSource.Play();

                while (audioSource.isPlaying)
                {
                    yield return null;
                }
                currentTrackIndex++;
            }
            else
            {
                currentTrackIndex = 0;
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
