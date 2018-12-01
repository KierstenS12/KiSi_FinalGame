using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiSi_DestroyByBoundary : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}