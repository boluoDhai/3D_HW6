using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private static Player _instance;
    public SceneController sceneControler { get; set; }
    public Recorder scoreRecorder;
    GameObject diskPrefab;
    public List<GameObject> used;
    public List<GameObject> free;

    private void Awake() {
        diskPrefab = Instantiate(Resources.Load<GameObject>("Prefabs/cube"), new Vector3(40, 0, 0), Quaternion.identity);
    }
    public void Start() {
        sceneControler.factory = this;
        scoreRecorder = sceneControler.scoreRecorder;
    }

    public void freeDisk(GameObject disk1)
    {
        for (int i = 0; i < used.Count; i++) {
            if (used[i] == disk1) {
                used.Remove(disk1);
                disk1.SetActive(true);
                free.Add(disk1);
            }
        }
        return;
    }
}
