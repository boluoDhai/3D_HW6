using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSAction : MonoBehaviour {
    protected static GameObject instance;
    public int ori_x;
    public int highest_x;
    public int a;
    public int b;
    public int c;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        if (ori_x < highest_x) pos.x += Time.deltaTime;
        else pos.x -= Time.deltaTime;
        float x = pos.x;
        pos.y = a * Mathf.Pow(x, 2) + b * x + c;
        //Debug.Log("x: " + x + ", y: " + pos.y + ", ori_x: " + ori_x + ", ori_y: " + ori_y + ", h_x: " + highest_x + ", h_y: " + highest_y + ", a: " + a + ", b: " + b + ", c: " + c);
        this.gameObject.transform.position = pos;
        if (pos.y < -20) {
            Destroy(this.gameObject);
            Recorder.missed += 1;
        }
        if (Recorder.score >= 20) Destroy(this.gameObject);
    }
}
