using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages colors used across scripts.
/// </summary>
public static class Colors
{
    private static Color32 s_white = new Color32(255, 255, 255, 255);
    private static Color32 s_semiTransparent = new Color32(0, 0, 0, 70);
    private static Color32 s_transparent = new Color32(0, 0, 0, 0);
    private static Color32 s_gold = new Color32(255, 255, 0, 255);
    private static Color32 s_brightGreen = new Color32(0, 255, 0, 255);
    private static Color32 s_grey = new Color32(135, 135, 135, 135);

    public static Color32 White
    {
        get
        {
            return s_white;
        }
    }

    public static Color32 SemiTransparent
    {
        get
        {
            return s_semiTransparent;
        }
    }

    public static Color32 Transparent
    {
        get
        {
            return s_transparent;
        }
    }

    public static Color32 Gold
    {
        get
        {
            return s_gold;
        }
    }
    public static Color32 BrightGreen
    {
        get
        {
            return s_brightGreen;
        }
    }
    public static Color32 Grey
    {
        get
        {
            return s_grey;
        }
    }
}
