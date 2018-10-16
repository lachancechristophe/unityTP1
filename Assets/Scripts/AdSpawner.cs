using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdSpawner : MonoBehaviour {

    [System.Serializable]
    public class AdSpawn
    {
        public int minTime, maxTime;
        public GameObject ad;
    }

    public Text pointageText;
    public Text viesText;
    public AdSpawn[] lstAdsToSpawn;

    const int MAXADS = 6;

    private int curAds = 0;
    private bool adBlockActive = false;
    private List<GameObject> lstAdsSpawned = new List<GameObject>();
    private static float deltaTot = 0;

    // Use this for initialization
    void Start()
    {
        SpawnAds();
    }

    private void SpawnAds()
    {

        foreach (AdSpawn v_tmp in lstAdsToSpawn)
        {
            bool fromLeft = (Random.Range(0, 5) > 2) ? true : false;
            StartCoroutine(spawn(v_tmp, fromLeft));
        }
    }

    private void FixedUpdate()
    {
        deltaTot += Time.deltaTime;
        if (deltaTot > 2 && !adBlockActive && (curAds < MAXADS))
        {
            SpawnAds();
            deltaTot = 0;
        }
        if (lstAdsSpawned.Count > 0 && adBlockActive) KillAllAds();
    }

    private void KillAllAds() { foreach (GameObject go in lstAdsSpawned) Destroy(go); lstAdsSpawned.Clear();  }
    public void ActivateAdBlock() { adBlockActive = true; }
    public void DisableAdBlock() { adBlockActive = false; }

    public void LowerAdCount() { curAds--; }
    public void ResetAdCount() { curAds = 0; }

    private IEnumerator spawn(AdSpawn v_tmp, bool fromLeft)
    {
        GameObject newAd;
        if (fromLeft)
        {
            newAd = Instantiate(v_tmp.ad, new Vector3(-4.3f, Random.Range(-2.67f, 1.78f), 0), Quaternion.identity);
            newAd.GetComponent<EnnemiController>().fromLeft = true;
        }
        else
        {
            newAd = Instantiate(v_tmp.ad, new Vector3(4.1f, Random.Range(-2.67f, 1.78f), 0), Quaternion.identity);
            newAd.GetComponent<EnnemiController>().fromLeft = false;
        }
        newAd.GetComponent<EnnemiController>().adspawn = this;
        newAd.GetComponent<EnnemiController>().pointageText = this.pointageText;
        newAd.GetComponent<EnnemiController>().viesText = this.viesText;
        curAds++;

        yield return null;
    }
}
