using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    StreamReader sr;
    StreamWriter sw;
    string path;
    int maxlvl;

    private void OnLevelWasLoaded()
    {

        path = DataHolder.path;
        maxlvl = DataHolder.Lvl;
        Debug.Log(maxlvl);
        int i = 1;
        GameObject g;
        while((g = GameObject.Find("Level" + i.ToString())) != null)
        {
            Image[] children = g.GetComponentsInChildren<Image>(true);
            int j = 0;
            while (j < children.Length && children[j].gameObject.name != "Lock")
                j++;
            if (j == children.Length)
                j = -1;

            if (i > maxlvl)
            {
                g.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 255);
                if (j != -1)
                    children[j].color = new Color(255, 255, 255, 255);
            }
            else
            {
                g.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                if (j != -1)
                    children[j].color = new Color(255, 255, 255, 0);
            }
            i++;
        }
    }
    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void ToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void ToLevel(int level)
    {
        if (level >= maxlvl)
            SceneManager.LoadScene("Level" + level.ToString());
    }
}
