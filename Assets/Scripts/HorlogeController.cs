using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorlogeController : MonoBehaviour {

    private Text texto;

    private void Awake()
    {
        texto = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        texto.text = System.DateTime.Now.ToShortTimeString();
    }
}
