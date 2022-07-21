using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAndOut : MonoBehaviour
{
    GameObject cam;
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Man")
        {
            if (name == "In")
            {
                transform.parent.gameObject.GetComponent<Gate>().InTime = cam.GetComponent<HUD>().GetTime();
            }
            if (name == "Out")
            {
                transform.parent.gameObject.GetComponent<Gate>().OutTime = cam.GetComponent<HUD>().GetTime();
            }
        }
    }
}
