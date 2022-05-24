using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("HeatParticle"))
            other.gameObject.GetComponent<QParticleBehaviour>().DisableHeatParticle();
        
    }
}
