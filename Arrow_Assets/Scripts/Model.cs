using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private GameObject sth;
    private int screen_width;
    private int screen_height;

    // Start is called before the first frame update
    void Start()
    {
        sth = Resources.Load<GameObject>("Prefab/Arrow");
        screen_width = Screen.width;
        screen_height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            Vector3 vec;
            if(Physics.Raycast(_ray, out _hit)) {
                vec = _hit.point;
                vec.z = Camera.main.transform.position.z + 1;
                sth.transform.position = vec;
                GameObject arrow = GameObject.Instantiate(sth);
                arrow.AddComponent<ModelController>();
                arrow.AddComponent<Rigidbody>();
            }
        }
    }
}
