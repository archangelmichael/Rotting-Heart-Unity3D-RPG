using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    private AudioClip audio;
    private AudioSource playingSound;


    void Start()
    {
        //audio = Resources.Load("intown") as AudioClip;
       // Debug.Log(audio == null);
        //playingSound = AudioManager.Instance.PlayLoop(audio, transform, 3);

    }

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.name);
        if (other.gameObject.name == "InTown")
        {
          //  Debug.Log("intown");
            PlaySound("intown");
        }

        if (other.gameObject.name == "OutsideTown")
        {
           // Debug.Log("outside");
            PlaySound("battle");
        }

        if (other.gameObject.name == "FinalBossEntrance")
        {
            //Debug.Log("entrance");
            PlaySound("story");
        }

        if (other.gameObject.name == "SpeakToBoss")
        {
            AudioManager.Instance.StopSound(playingSound);
            audio = Resources.Load("silence") as AudioClip;
            AudioManager.Instance.Play(audio, new Vector3(), 10);
        }
    }

    private void PlaySound(string tag)
    {
        if (playingSound.clip.name != tag)
        {
            Debug.Log(playingSound.clip.name + " " + tag);
            AudioManager.Instance.StopSound(playingSound);
            audio = Resources.Load(tag) as AudioClip;
            playingSound = AudioManager.Instance.PlayLoop(audio, transform, 3); 
        }
    }

    void OnTriggerExit(Collider other)
    {
       // Debug.Log(other.name);
        //AudioManager.Instance.StopSound(playingSound);
    }

}
