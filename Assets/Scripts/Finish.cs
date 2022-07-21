using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Kayak")
        {
            GameObject.Find("Main Camera").GetComponent<HUD>().End();
        }
    }
}
