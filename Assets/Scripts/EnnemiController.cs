using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnnemiController: MonoBehaviour {

    public Text pointageText;
    public Text viesText;
    public bool fromLeft;
    public AdSpawner adspawn;

    private int speed;


    public void Awake()
    {
        speed = Random.Range(1, 6);
    }
    public void Update()
    {
        Vector3 direction = fromLeft ? Vector3.right : Vector3.left;
        this.transform.Translate(direction * Time.deltaTime * speed, Space.World);

        if (fromLeft && this.transform.position.x > 4.1)    KillThis();
        if (!fromLeft && this.transform.position.x < -4.3)  KillThis();
    }

    private void KillThis()
    {
        adspawn.LowerAdCount();
        Destroy(this.gameObject);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        pointageText.GetComponent<PointageController>().ResetScore();

        viesText.GetComponent<ViesController>().PerdreVie();
        
        adspawn.ResetAdCount();
    }
}
