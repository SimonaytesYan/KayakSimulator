using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stars
{
    
    public static int GetStars(int lvl, double time)
    {
        if (lvl == 1)
        {
            if (time > 15)
                return 0;
            //if (time )
            return 3;
        }
        else
        {
            return -1;
        }
    }
}
