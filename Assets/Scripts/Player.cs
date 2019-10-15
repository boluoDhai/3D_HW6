using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GameObject cube;
    public GameObject cylinder;
    public GameObject sphere;
    public GameObject pie1;
    public GameObject pie2;

    public Material red;
    public Material green;
    public Material blue;

    /*
    public static int score;
    public static int missed;

    public static int round;
    */

    private const float x_min = 1;
    private const float x_max = 15 + 1;
    private const float y_init = -8;

    public Player() {
        red = Resources.Load<Material>("Materials/Red");
        green = Resources.Load<Material>("Materials/Green");
        blue = Resources.Load<Material>("Materials/Blue");
        cube = Resources.Load<GameObject>("Prefabs/Cube");
        cylinder = Resources.Load<GameObject>("Prefabs/Cylinder");
        sphere = Resources.Load<GameObject>("Prefabs/Sphere");
        pie1 = Resources.Load<GameObject>("Prefabs/Pie1");
        pie2 = Resources.Load<GameObject>("Prefabs/Pie2");
    }

    void changeColor(ref GameObject arg) {
        int color = Random.Range(0, 3);
        if (color == 0) arg.GetComponent<Renderer>().material = red;
        else if (color == 1) arg.GetComponent<Renderer>().material = green;
        else arg.GetComponent<Renderer>().material = blue;
    }

    float getPostionX() {
        float x = Random.Range(x_min, x_max);
        if (Random.Range(0, 2) == 0) return x;
        else return -x;
    }

    public void createObject() {
        GameObject sth;
        int c = Random.Range(0, 5);
        if (c == 0) sth = cube;
        else if (c == 1) sth = cylinder;
        else if (c == 2) sth = sphere;
        else if (c == 3) sth = pie1;
        else sth = pie2;
        sth.transform.position = new Vector3(getPostionX(), y_init, 0);
        changeColor(ref sth);
        sth = GameObject.Instantiate(sth);
        sth.AddComponent<SSActionManager>();
    }
}
