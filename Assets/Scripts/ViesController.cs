using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViesController : MonoBehaviour {
    private static int vies = 5;
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

    private void Mourir()
    {
        ResetVies();
        endpanel.GetComponent<RestartCtrl>().ShowPanel(false);
    }

    public void PerdreVie()
    {
        if (vies >= 1)
        {
            vies--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        else Mourir();
        
    }

    public void ResetVies() {  vies = 3; }

    public int GetVies() { return vies; }
}
