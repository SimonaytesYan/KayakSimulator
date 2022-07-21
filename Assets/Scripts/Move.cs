using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 1.5f;
    float rotationSpeed = 1.5f;
    float bRotationSpeed = 2.5f;
    float bSpeed = 0.5f;
    public void GoStraight()
    {
        float ang = transform.localEulerAngles.z * Mathf.Deg2Rad;
        float l = 1f * speed;
        float x = -l * Mathf.Sin(ang);
        float y = l * Mathf.Cos(ang);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
    public void GoRight()
    {
        GetComponent<Rigidbody2D>().AddTorque(0.1f * rotationSpeed, ForceMode2D.Impulse);
        GoStraight();
    }
    public void GoLeft()
    {
        GetComponent<Rigidbody2D>().AddTorque(-0.1f * rotationSpeed, ForceMode2D.Impulse);
        GoStraight();
    }
    public void GoBack()
    {
        float ang = transform.localEulerAngles.z * Mathf.Deg2Rad;
        float l = 1f * bSpeed;
        float x = l * Mathf.Sin(ang);
        float y = -l * Mathf.Cos(ang);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
    public void GoBRight()
    {
        GetComponent<Rigidbody2D>().AddTorque(-0.1f * bRotationSpeed, ForceMode2D.Impulse);
        GoBack();
    }
    public void GoBLeft()
    {
        GetComponent<Rigidbody2D>().AddTorque(0.1f * bRotationSpeed, ForceMode2D.Impulse);
        GoBack();
    }

}
