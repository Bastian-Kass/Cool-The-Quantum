using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QParticleBehaviour : MonoBehaviour
{
    [System.NonSerialized]
    public UnityEvent<QParticleBehaviour> particleDisabled;

    private Rigidbody _rigidbody;

    public float speed = 12;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if (particleDisabled == null)
            particleDisabled = new UnityEvent<QParticleBehaviour>();

        if(_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.rotation * Vector3.forward * speed);
    }


    public void DisableHeatParticle(){
        particleDisabled.Invoke(this);
        particleDisabled.RemoveAllListeners();
        gameObject.SetActive(false); 
    }
}
