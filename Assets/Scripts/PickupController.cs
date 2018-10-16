using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupController : MonoBehaviour {

    public int nextScene;
    public bool warp;
    public Text pointageText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        pointageText.GetComponent<PointageController>().AjouterPoint();

        Destroy(this.gameObject);
        if (warp)
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
