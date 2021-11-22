using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock {
    public int Hour { get; set; }
    public int Minute { get; set; }

    private int timer;

    public Clock(int startingHour, int startingMinute)
    {
        this.Hour = startingHour;
        this.Minute = startingMinute;
    }
    
    public static Clock operator +(Clock a, Clock b) {
        int hour = a.Hour + b.Hour;
        int minute = a.Minute + b.Minute;

        if (minute >= 60)
        {
            hour += (minute / 60);
            minute %= 60;
        } 
        else if (minute < 0)
        {
            hour = (minute / 60);
            minute %= 60;
            minute = 60 - minute;
        }

        return new Clock(hour, minute);
    }

    public static bool operator ==(Clock a, Clock b)
    {
        return a.Hour == b.Hour && a.Minute == b.Minute;
    }

    public static bool operator !=(Clock a, Clock b)
    {
        return a.Hour != b.Hour || a.Minute != b.Minute;
    }

    public string GetTimeString()
    {
        return $"{ Hour }:{ Minute }";
    }
}