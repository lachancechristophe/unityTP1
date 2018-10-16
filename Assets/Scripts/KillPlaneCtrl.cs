using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillPlaneCtrl : MonoBehaviour {
    public Text pointageText;
    public Text viesText;
    bool skip = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (skip) { skip = false; return; }

        pointageText.GetComponent<PointageController>().ResetScore();
        viesText.GetComponent<ViesController>().PerdreVie();
  
        skip = true;
    }
}
