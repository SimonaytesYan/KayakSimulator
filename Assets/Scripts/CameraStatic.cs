using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Kayak");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 now = player.transform.position;
        now.y += 3;
        now.z = -10;
        transform.position = now;
    }
}
