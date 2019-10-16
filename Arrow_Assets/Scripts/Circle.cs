using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle
{
    private GameObject circle1;
    private GameObject circle2;
    private GameObject circle3;
    private GameObject circle4;
    private GameObject circle5;

    public Circle() {
        circle1 = Resources.Load<GameObject>("Prefab/Circle1");
        circle1 = GameObject.Instantiate(circle1);
        circle2 = Resources.Load<GameObject>("Prefab/Circle2");
        circle2 = GameObject.Instantiate(circle2);
        circle3 = Resources.Load<GameObject>("Prefab/Circle3");
        circle3 = GameObject.Instantiate(circle3);
        circle4 = Resources.Load<GameObject>("Prefab/Circle4");
        circle4 = GameObject.Instantiate(circle4);
        circle5 = Resources.Load<GameObject>("Prefab/Circle5");
        circle5 = GameObject.Instantiate(circle5);

        /*circle2.transform.parent = circle1.transform;
        circle3.transform.parent = circle1.transform;
        circle4.transform.parent = circle1.transform;
        circle5.transform.parent = circle1.transform;*/

        circle1.AddComponent<Score>();
        circle2.AddComponent<Score>();
        circle3.AddComponent<Score>();
        circle4.AddComponent<Score>();
        circle5.AddComponent<Score>();

        circle1.name = "1";
        circle2.name = "2";
        circle3.name = "3";
        circle4.name = "4";
        circle5.name = "5";
    }
}
