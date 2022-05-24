using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class QToolCollector : MonoBehaviour
{
    public GameManager gameManager;
    public QCollectorPointerColliderBehaviour pointerCollider;

    public TriggerWatcher triggerWatcher;

    void OnEnable(){
        triggerWatcher.triggerPress.AddListener(TryCollectQNodePoints);
    }

    void OnDisable(){
        triggerWatcher.triggerPress.RemoveListener(TryCollectQNodePoints);
    }

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(gameManager);
    }

    // Update is called once per frame
    public void TryCollectQNodePoints()
    {
        int collidingPointsSum = 0;

        foreach(QuBit node in pointerCollider.QNodes){
            collidingPointsSum =  node.CollectNodePoints();
        }

        gameManager.AddQPoints(collidingPointsSum);

    }
}
