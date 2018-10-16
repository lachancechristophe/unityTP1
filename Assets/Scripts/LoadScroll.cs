using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScroll : MonoBehaviour {

    private Transform loadTr;
    private static int loadCount = 0;
	// Use this for initialization
	void Awake() {
        loadTr = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0f, 1f) > 0.95)
            if (loadTr.position.x <= 0.66f)
                loadTr.position = new Vector3(loadTr.position.x + .2f, loadTr.position.y, loadTr.position.z);
            else
            {
                loadTr.position = new Vector3(-.73f, loadTr.position.y, loadTr.position.z);
                loadCount++;
            }
        if (loadCount >= 4)
            SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
