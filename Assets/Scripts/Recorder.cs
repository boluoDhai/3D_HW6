using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder
{
    public static int score;
    public static int missed;

    public static int round;

    public Recorder() {
        score = missed = 0;
        round = 1;
    }

}
