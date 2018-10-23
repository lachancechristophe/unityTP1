using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViesController : MonoBehaviour {
    private static int vies = 3;
    private Text texto;

    public GameObject endpanel;

    public void Awake()
    {
        texto = GetComponent<Text>();
    }

    public void FixedUpdate()
    {
        texto.text = "Vies: " + vies.ToString();
    }

    private void GameOver()
    {
        endpanel.GetComponent<RestartCtrl>().ShowPanel(false);
        ResetVies();

    }

    public void PerdreVie()
    {
        if (vies >= 1)
        {
            vies--;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else GameOver();
        
    }

    public void ResetVies() {  vies = 3; }

    public int GetVies() { return vies; }
}
