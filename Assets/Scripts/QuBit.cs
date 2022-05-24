using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider))]
public class QuBit : MonoBehaviour
{
    // Data variables
    [Header("QuBit: General setting")]
    [Range(1, 50)]
    public int QPointsMax = 15;
    public int QPoints { get; private set; }
    public int Multiplier { get; private set; }

    // TODO: Will be generated randomly Normal distribution
    [Range(1, 6)]
    public float LifeCycleTime = 3;
    
    // Interface variables
    public TextMeshPro pointsIndicator;

    // Internal variables
    public HashSet<QParticleBehaviour> ParticlesCollided = new HashSet<QParticleBehaviour>();
    public List<Action> OnParticleHitCallbacks = new List<Action>();

    private IEnumerator LifeCycle;

    // Start is called before the first frame update
    void OnEnable()
    {
        Initializer();
    }

    public virtual void Initializer (){
        // TODO: Make tool to change QPoints based on the game state, etc
        QPointsMax = 15;
        QPoints = 0;
        Multiplier = 1;
        pointsIndicator.text = QPoints.ToString();

        //Starting QuBit Lifecycle
        LifeCycle = StartLifeCycle();
        StartCoroutine(LifeCycle);
    }

    IEnumerator StartLifeCycle(){
        // while(isActiveAndEnabled && Health > 0){
        while(isActiveAndEnabled){
            //TODO: Set lifecycle to be random in a normal distribution
            yield return new WaitForSeconds(LifeCycleTime);
            
            if(QPoints < QPointsMax)
                AddQPoints(1 * Multiplier);
   
        }
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        /* 
            NOTE: Collision needs to only register once for each particle lifecycle
             - Save collided particle in list to not trigger again
             - Get the particle off the list when it has been disables ( Register a listener for its disablement )
        */

        
        if (other.gameObject.CompareTag("HeatParticle")){


            QParticleBehaviour particle = other.gameObject.GetComponent<QParticleBehaviour>();

            if(particle != null && !ParticlesCollided.Contains(particle)){

                SetQPoints(0);

                foreach (var callback in OnParticleHitCallbacks)
                    callback();
                

                //Adding reference to ignore further collisions with this object
                ParticlesCollided.Add(particle);
                particle.particleDisabled.AddListener(QParticleDisabled);
            }

            
        }

    }

    private void SetQPoints(int points){
        QPoints = points;
        pointsIndicator.text = QPoints.ToString();
    }

    private void AddQPoints(int points){
        QPoints += points;
        pointsIndicator.text = QPoints.ToString();
    }

    private void QParticleDisabled(QParticleBehaviour qpb){
        ParticlesCollided.Remove(qpb);
    }

    public int CollectNodePoints(){
        int collectedPoints = QPoints;
        SetQPoints(0);
        return collectedPoints;
    }



}
