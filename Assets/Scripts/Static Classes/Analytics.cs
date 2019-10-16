using UnityEngine;
using System.Collections;

public static class Analytics {

    public static int attempts;
    public static int score;

    public static void Reset () {
        attempts = 5;
        score = 0;
    }
}
