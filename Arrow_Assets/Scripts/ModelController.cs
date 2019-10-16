using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    private float speed;
    private bool fly;

    // Start is called before the first frame update
    void Start()
    {
        fly = true;
        speed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -5) {
            Destroy(this.gameObject);
        }
        if (fly) {
            Vector3 vec = this.gameObject.transform.position;
            vec.z -= -speed * Time.deltaTime;
            this.gameObject.transform.position = vec;
        }
    }

    void OnCollisionEnter(Collision collision) {
        fly = false;
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
    }
}
