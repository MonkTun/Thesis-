using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    //public static void SetFontSize
    public static float FontSize { get; private set; }
    
    public static float ScrollSensitivity { get; private set; }
    
    public static float SfxVolume { get; private set; }
    
    public static bool ProgressIndicatorOnRight { get; private set; }
    
    public static bool LeaveButtonOnLeft { get; private set; }

    public static void SetFontSize(float value)
    {
        FontSize = value;
    }

    public static void SetScrollSensitivity (float value)
    {
        ScrollSensitivity = value;
    }

    public static void SetSFXVolume(float value)
    {
        SfxVolume = value;
    }

    public static void SetProgressIndicatorOnRight(bool value)
    {
        ProgressIndicatorOnRight = value;
    }
    
    public static void SetLeaveButtonOnLeft(bool value)
    {
        LeaveButtonOnLeft = value;
    }
}
