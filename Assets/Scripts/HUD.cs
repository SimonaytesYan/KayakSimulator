using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject endPanel, pausePanel;
    bool end = false , GoTimer = true;
    private int penalty = 0;
    float time = 0;
    int lvl = 0;
    GameObject timer, judge, kayak, course, shadowT, shadowJ;
    StreamWriter sw;
    private void Start()
    {
        string name = SceneManager.GetActiveScene().name;

        string LVL = "";
        for(int j = 0; j < name.Length; j++)
        {
            if (name[j] == '0' || name[j] == '1' || name[j] == '2' || name[j] == '3' || name[j] == '4' || name[j] == '5' || name[j] == '6' || name[j] == '7' || name[j] == '8' || name[j] == '9')
            {
                LVL += name[j];
            }
        }
        lvl = Int32.Parse(LVL);

        shadowT = GameObject.Find("Time1");
        kayak = GameObject.Find("Kayak");
        timer = GameObject.Find("Time");
        shadowJ = GameObject.Find("Judge1");
        judge = GameObject.Find("Judge");
        course = GameObject.Find("Course");
    }
    void Update()
    {
        if (GoTimer && !end)
        {
            time += Time.deltaTime;
            timer.GetComponent<Text>().text = time.ToString("F2");
            shadowT.GetComponent<Text>().text = time.ToString("F2");
        }
    }

    public void ChangePenalty(int x)
    {
        penalty += x;
        string txt = "Penalty: " + penalty.ToString();
        judge.GetComponent<Text>().text = txt;
        shadowJ.GetComponent<Text>().text = txt;
    }

    public int GetPenalty()
    {
        return penalty;
    }

    public float GetTime()
    {
        return time;
    }

    public void End()
    {
        end = true;
        GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate");

        ChangePenalty(gates.Length*50);

        GameObject.Find("Course").GetComponent<Course>().End = true;
        GameObject.Find("InGame").SetActive(false);

        endPanel.SetActive(true);
        double total = time + penalty;
        GameObject.Find("EndPenalty").GetComponent<Text>().text = "Penalty: " + penalty.ToString();
        GameObject.Find("EndTime").GetComponent<Text>().text = "Time: " +  time.ToString("F2");
        GameObject.Find("Total").GetComponent<Text>().text = "Total: " + total.ToString("F2");

        int stars = Stars.GetStars(lvl, total);
        Sprite YStar = Resources.Load<Sprite>("Sprites/UI/Star");
        for (int i = 1; i <= stars; i++)
        {
            GameObject.Find("Star" + i.ToString()).GetComponent<Image>().sprite = YStar;
        }

        if (stars > 0)
        {
            DataHolder.Lvl = Math.Max(DataHolder.Lvl, lvl + 1);
            //Debug.Log(DataHolder.Lvl);
        }
    }

    public void Pause(bool flag)
    {
        if (flag)
        {
            GoTimer = false;
            pausePanel.SetActive(true);
            kayak.GetComponent<Rigidbody2D>().simulated = false;
            course.GetComponent<Course>().End = true;
            Debug.Log("HelloTheir");
        }
        else
        {
            pausePanel.SetActive(false);
            kayak.GetComponent<Rigidbody2D>().simulated = true;
            course.GetComponent<Course>().End = false;
            GoTimer = true;
        }
    }

}
