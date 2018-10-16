using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBlock : MonoBehaviour {
    public AdSpawner adSpawn;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        adSpawn.ActivateAdBlock();
        adSpawn.enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine("enableAds");
    }

    private IEnumerator enableAds()
    {
        yield return new WaitForSeconds(5);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        adSpawn.enabled = true;
        adSpawn.DisableAdBlock();
    }
}
