using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;


public class QToolBehaviour : MonoBehaviour
{

    public TriggerWatcher triggerWatcher;

    private Renderer _renderer;
    public GameObject ToolPointer;
    public GameManager gameManager;

    AudioSource audioData;

    void OnEnable(){
        triggerWatcher.triggerPress.AddListener(tryPlaceQNode);
    }

    void OnDisable(){
        triggerWatcher.triggerPress.RemoveListener(tryPlaceQNode);
    }

    void Start()
    {
        Assert.IsNotNull(gameManager);
        audioData = GetComponent<AudioSource>();
        
        _renderer = ToolPointer.GetComponent<Renderer>();
    }

    public void tryPlaceQNode(){

        bool res = gameManager.BuyQNode(ToolPointer.transform.position, 5);

        if(!res)
            audioData.Play(0);

        
            


    }

}