using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GUIStyle style;

    private bool next;

    private float T = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        next = true;
        style = new GUIStyle();
        style.fontSize = 40;
        InvokeRepeating("runGame", 0, T);
    }

    // Update is called once per frame
    void Update()
    {
        if (Recorder.score >= 20) {
            if (Recorder.round < 3 && next) {
                Invoke("reset", 3);
                CancelInvoke("runGame");
                Invoke("goNext", 3);
                next = false;
            } else CancelInvoke("runGame");
        } else next = true;
    }

    private void OnGUI() {
        GUI.Label(new Rect(Screen.width / 8, Screen.height / 6, 200, 100), "Round: " + Recorder.round + "\nScore: " + Recorder.score + "\nMissed: " + Recorder.missed, style);
        if(Recorder.round >= 3 && Recorder.score >= 20) {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "You win!", style);
        }else if(Recorder.score >= 20) {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 200, 200), "Next round will start after 3s", style);
        }
    }

    void reset() {
        Recorder.score = Recorder.missed = 0;
        Recorder.round += 1;
        T /= 2;
    }

    void goNext() {
        InvokeRepeating("runGame", 0, T);
    }

    void runGame() {
        Player mplayer = new Player();
        mplayer.createObject();
    }
}
