using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audio;
    AudioClip spoke1, spoke2;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        string path = "Sounds/Stroke1";
        spoke1 = Resources.Load<AudioClip>(path);
        Debug.Log(spoke1);
        path = "Sounds/Stroke2";
        spoke2 = Resources.Load<AudioClip>(path);
    }
    public void DoStroke()
    {
        if (Random.Range(0, 2) == 1)
        {
            //audio.PlayOneShot(spoke1);
        }
        else
        {
            //audio.PlayOneShot(spoke2);
        }
    }
}
