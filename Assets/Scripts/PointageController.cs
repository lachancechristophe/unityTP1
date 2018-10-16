using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointageController : MonoBehaviour {
    private static int pointage = 0;
    private Text texto;
    private bool skip = false;

    public GameObject endpanel;

    public void Awake()
    {
        texto = GetComponent<Text>();
    }

    public void FixedUpdate()
    {
        texto.text = "Score: " + pointage.ToString();
    }

    public void AjouterPoint()
    {
        if (!skip) { pointage++; skip = true; }
        else skip = false;

        if(pointage >= 5) endpanel.GetComponent<RestartCtrl>().ShowPanel(true);
    }

    public void ResetScore() { pointage = 0; }

    public int GetScore() { return pointage; }
}
