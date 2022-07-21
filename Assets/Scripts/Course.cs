using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    public bool End = false;
    public bool Catch = false;
    float CourseSpeed = 0.005f;
    public float FPS = 29;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!End && !Catch)
        {
            //FPS = 29;
            FPS = (int)(1f / Time.unscaledDeltaTime);
            //Debug.Log(FPS);
            if (FPS != 0)
                gameObject.transform.position += new Vector3(0, -CourseSpeed*300/FPS, 0);
        }
    }
}
