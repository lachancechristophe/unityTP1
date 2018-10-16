using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitcoinSpawner : MonoBehaviour {
    public Text pointageText;
    public GameObject btc;

    const int MAXBITCOIN = 32;

    private int curBtc = 0;
    private List<GameObject> lstBtcSpawned = new List<GameObject>();
    private static float deltaTot = 0;

    // Use this for initialization
    void Start()
    {
        SpawnBtc();
    }

    private void FixedUpdate()
    {
        deltaTot += Time.deltaTime;
        if (deltaTot > 2 &&  (curBtc < MAXBITCOIN))
        {
            SpawnBtc();
            deltaTot = 0;
        }
    }

    private void KillAllBtc() { foreach (GameObject go in lstBtcSpawned) Destroy(go); lstBtcSpawned.Clear(); }

    public void LowerAdCount() { curBtc--; }
    public void ResetAdCount() { curBtc = 0; }

    private void SpawnBtc()
    {
        GameObject newBtc;

        // x0 = -5  | y0 =  2.4
        // xM = 4.8 | yM = -3.3
        newBtc = Instantiate(btc, new Vector3(Random.Range(-5.1f, 4.85f), Random.Range(-3.3f, 2.4f), 0), Quaternion.identity);
        newBtc.GetComponent<PickupController>().pointageText = this.pointageText;
        curBtc++;

        lstBtcSpawned.Add(newBtc);
    }
}
