using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Control : MonoBehaviour
{
    bool mouseDown;
    GameObject kayak;
    GameObject audioPlayer;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        kayak = GameObject.Find("Kayak");
        audioPlayer = GameObject.Find("AudioPlayer");
    }
    public void StrokeR()
    {
        audioPlayer.GetComponent<AudioPlayer>().DoStroke();
        animator.SetBool("RightStroke", true);
        kayak.GetComponent<Move>().GoRight();
    }
    public void StrokeL()
    {
        audioPlayer.GetComponent<AudioPlayer>().DoStroke();
        animator.SetTrigger("LeftStroke");
        kayak.GetComponent<Move>().GoLeft();
    }
    public void StrokeRR()
    {
        audioPlayer.GetComponent<AudioPlayer>().DoStroke();
        animator.SetBool("RightStroke", false);
        kayak.GetComponent<Move>().GoBRight();
    }
    public void StrokeLR()
    {
        audioPlayer.GetComponent<AudioPlayer>().DoStroke();
        kayak.GetComponent<Move>().GoBLeft();
    }
}
