using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiSi_GameController : MonoBehaviour
{
    public GameObject tennisBall;
    public Vector3 spawnValues;
    public int ballCount;
    public float spawnWait;
    public float startWait;


    void Start()
    {
        void Start()
        {
            StartCoroutine(SpawnWaves());
        }


        IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < ballCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                    Quaternion spawnRotation = new Quaternion();
                    Instantiate(tennisBall, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
    }
}
