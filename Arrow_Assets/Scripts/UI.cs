using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GUIStyle style;
    private Circle mcircle;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 40;
        style.normal.textColor = new Color(1, 1, 1, 1);
        mcircle = new Circle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        GUI.Label(new Rect(20, 20, 200, 100), "Score: " + Recorder.score, style);

    }
}
