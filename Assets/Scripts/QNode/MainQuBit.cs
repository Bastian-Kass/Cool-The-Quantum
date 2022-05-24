using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class MainQuBit : QuBit
{
    [Space(10)]
    [Header("Main QuBit: Health Settings")]
    [Range(1, 5)]
    public int HealthMax;
    public TextMeshPro healthIndicator;
    public UnityEvent HealthDepleted;


    public int Health { get; private set; }

    override public void Initializer (){
        base.Initializer();

        HealthDepleted = new UnityEvent();

        // TODO: Make tool to change Max Health based on the game state, etc
        HealthMax = 3;
        Health = HealthMax;
        healthIndicator.text = Health.ToString();

        OnParticleHitCallbacks.Add (SubtractHealth);
    }

    private void SubtractHealth(){
        Health--;
        healthIndicator.text = Health.ToString();

        Debug.Log(Health);

        if(Health == 0){
            HealthDepleted.Invoke();
        }
    }

}
