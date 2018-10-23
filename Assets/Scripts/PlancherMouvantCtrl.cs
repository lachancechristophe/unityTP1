using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlancherMouvantCtrl : MonoBehaviour {

    public float speed = 3;
    private bool goingRight = true;
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x >= 3) goingRight = false;   
        if(transform.position.x <= -2) goingRight = true;

        Vector3 direction = goingRight ? Vector2.right : Vector2.left;
        transform.position += direction * speed * Time.deltaTime;
	}
}
