using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartCtrl : MonoBehaviour {

    // Use this for initialization

    public Text winText, loseText, pointage, vies;

    public void RestartGame()
    {
        pointage.GetComponent<PointageController>().ResetScore();
        vies.GetComponent<ViesController>().ResetVies();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ShowPanel(bool win)
    {
        this.gameObject.SetActive(true);
        if (win)
            winText.enabled = true;
        else
            loseText.enabled = true;
    }
}
