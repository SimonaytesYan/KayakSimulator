using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//Структура файла сохранения:
//Первая строка - последний доступная локация (Кодируется функцией y = k/x, где x - последний доступная локация, а y - то, что записывается в файл)
//Количество денег (Кодируется функцией y = x^2 - l)
//Купленные лодки(?)
//
//
//
public static class DataHolder
{
    //Application.dataPath + 
    public static string path = "content.txt";
    private static List<string> save = new List<string>(2);
    private static int maxlvl = 1, money = 0;
    public const int k = 116396280, l = 100;

    public static int Lvl
    {
        get { 
            Get();
            return maxlvl; 
        }
        set
        {
            maxlvl = value;
            ReWrite();
        }
    }
    public static int Money
    {
        get { return money; }
        set
        {
            money = value;
            ReWrite();
        }
    }

    static double cryptLvl(int x)
    {
        return k / (double)x;
    }

    static double crytpMoney(int x)
    {
        return x * x - l;
    }
    static int EnCryptLvl(double y)
    {
        return (int)(k / y);
    }
    static int EnCrytpMoney(int y)
    {
        return (int)Math.Sqrt(y + l);
    }
    public static void Get()
    {
        if (save.Count < 2)
        {
            save.Add("");
            save.Add("");
        }
        save[0] = cryptLvl(maxlvl).ToString();
        save[1] = crytpMoney(money).ToString();
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            save.Clear();
            string s;
            while ((s = sr.ReadLine()) != null)
                save.Add(s);
            sr.Close();

            if (save.Count < 2)
            {
                save.Add(cryptLvl(maxlvl).ToString());
                save.Add(crytpMoney(money).ToString());
            }
            else
            {
                double y = Int32.Parse(save[0]);
                maxlvl = EnCryptLvl(y);
                y = Int32.Parse(save[1]);
                money = EnCrytpMoney((int)y);
            }
        }
        else
        {
            File.CreateText(path);
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(save[0]);
            sw.WriteLine(save[1]);
            sw.Close();
        }
    }
    static void ReWrite()
    {
        if (File.Exists(path))
        {
            StreamWriter sw = new StreamWriter(path);
            save[0] = cryptLvl(maxlvl).ToString();
            save[1] = crytpMoney(money).ToString();
            for (int i = 0; i < save.Count; i++)
                sw.WriteLine(save[i]);
            sw.Close();
        }
        else
        {
            File.CreateText(path);
            StreamWriter sw = new StreamWriter(path);
            save[0] = (k / maxlvl).ToString();
            save[1] = (money * money - l).ToString();
            for (int i = 0; i < save.Count; i++)
                sw.WriteLine(save[i]);
            sw.Close();
        }
    }

}
