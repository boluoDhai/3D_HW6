using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public SSAction actionManager { get; set; }
    public Factory factory { get; set; }
    public Recorder scoreRecorder { get; set; }
    public int round = 0;
    public string str;
    public int mtime = 0;
    public GameObject sth;

    void Start() {
        round = 1;
    }

    // Update is called once per frame
    void Update() {
        str = "Round:" + round.ToString();
        if (round == 4) {
            GameOver();
        }
    }
    public IEnumerator waitForOneSecond() 
    {
        while (mtime >= 0 && round == 3) {
            str = mtime.ToString(); 
            print("还剩" + mtime);
            yield return new WaitForSeconds(1);
            mtime--;
        }
        str = "";
        round = 1;  //标记游戏开始
    }
    public void GameOver() {
        str = "Game Over!!!";
    }
    public void StartGame()
    {
        if (round == 0) {
            round = 3;
            StartCoroutine(waitForOneSecond());
        }
    }
    public void ReStart()
    {
        round = 0;
    }
    public void ShowDetail() 
    {
        GUI.Label(new Rect(220, 50, 350, 250), "Use your mouse click disk, you will get 1 point for green Disk，2 for yellow Disk，3 for red Disk,you should get 20 points to pass round1,40 to pass round2,60 to pass round3.There are three round.Good Luck!!!");
    }
    public void hit()
    {
        if (round == 1) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.tag == "Disk") {
                    sth.transform.position = hit.collider.gameObject.transform.position;
                    sth.GetComponent<Renderer>().material = hit.collider.gameObject.GetComponent<Renderer>().material;
                    sth.GetComponent<ParticleSystem>().Play();
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
    public void LoadResources()  //载入资源
    {
        sth = Instantiate(Resources.Load("prefabs/Explosion"), new Vector3(-40, 0, 0), Quaternion.identity) as GameObject;
        Instantiate(Resources.Load("prefabs/Light"));
    }
}
