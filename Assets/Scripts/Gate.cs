using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float InTime = -1;
    public float OutTime = -1;
    bool passed = false;
    protected void Update()
    {
        if (InTime != -1 && OutTime != -1 && !passed)
        {
            float delta = OutTime - InTime;
            if (delta < 0.3f &&  delta >= 0)
            {
                Passed();
            }
            if (delta < 0)
            {
                passed = true;
                //GameObject.Find("Main Camera").GetComponent<HUD>().ChangePenalty(50);
                Destroy(gameObject);
            }
        }
    }

    protected void Passed()
    {
        passed = true;
        Destroy(gameObject);

    }
}
