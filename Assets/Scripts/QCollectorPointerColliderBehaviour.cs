using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QCollectorPointerColliderBehaviour : MonoBehaviour
{
    public HashSet<QuBit> QNodes;

    void Start()
    {
        QNodes = new HashSet<QuBit>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("QNode")){
            QuBit qnode = other.gameObject.GetComponent<QuBit>();
            QNodes.Add(qnode);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("QNode")){
            QuBit qnode = other.gameObject.GetComponent<QuBit>();
            QNodes.Remove(qnode);
        }
    }


}
