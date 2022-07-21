using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    GameObject course;
    public void Start()
    {
        course = GameObject.Find("Course");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Catch");
        if (collision.name == "Man")
        {
            course.GetComponent<Course>().Catch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Man")
        {
            course.GetComponent<Course>().Catch = false;
        }
    }
}
