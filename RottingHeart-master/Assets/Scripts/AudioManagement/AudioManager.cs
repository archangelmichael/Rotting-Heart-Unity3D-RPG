using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    private class ClipInfo
    {
        public AudioSource Source { get; set; }
        public float DefaultVolume { get; set; }
    }

    private List<ClipInfo> m_activeAudio;

    public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume)
    {
        //Create an empty game object
        GameObject soundLoc = new GameObject("Audio: " + clip.name);
        soundLoc.transform.position = soundOrigin;

        //Create the source
        AudioSource source = soundLoc.AddComponent<AudioSource>();
        SetSource(ref source, clip, volume);
        source.Play();
        Destroy(soundLoc, clip.length);

        //Set the source as active
        m_activeAudio.Add(new ClipInfo { Source = source, DefaultVolume = volume });
        return source;
    }

    private void SetSource(ref AudioSource source, AudioClip clip, float volume)
    {
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.dopplerLevel = 0.2f;
        source.minDistance = 150;
        source.maxDistance = 1500;
        source.clip = clip;
        source.volume = volume;
    }

    void Awake()
    {
        m_activeAudio = new List<ClipInfo>();
        Debug.Log("AudioManager Initializing");
        try
        {
            transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
            transform.localPosition = new Vector3(0, 0, 0);
        }
        catch
        {
            Debug.Log("Unable to find main camera to put audiomanager");
        }
    }
}