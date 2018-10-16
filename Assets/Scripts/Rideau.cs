using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rideau : MonoBehaviour {

    private Transform rideauTransform;
	// Use this for initialization
	void Awake() {
        rideauTransform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0f, 1f) > 0.9)
            rideauTransform.position = new Vector3(rideauTransform.position.x, rideauTransform.position.y - 0.5f, rideauTransform.position.z);
        if (rideauTransform.position.y <= -10)
            Destroy(gameObject);
                //SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
