using UnityEngine;
using System.Collections;

public class AudioSound : MonoBehaviour 
{
    private string theCollider;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        theCollider = other.tag;
        if (theCollider == "Player")
        {
            audio.Play();
            audio.loop = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        theCollider = other.tag;
        if (theCollider == "Player")
        {
            audio.Stop();
            audio.loop = false ;
        }
    }
}


