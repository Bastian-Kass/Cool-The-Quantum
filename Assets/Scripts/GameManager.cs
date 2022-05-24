using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject QNodePrefab;

    public TextMeshPro QuPoints_text;
    private int _QuPoints = 0;
    public int QuPoints
    {
        get { return _QuPoints; }
        set { _QuPoints = value; QuPoints_text.text = _QuPoints.ToString(); }
    }

    public int HighScoreQuPoints = 0;

    public enum GameStateType  
    {
        Awake,
        Bootstrap,
        Playing,
        Scoring,
        FinishedGame,
    }

    [System.NonSerialized]
    public UnityEvent<GameStateType> OnChangeGameState;

    private GameStateType _GameState = GameStateType.Awake;
    public GameStateType GameState
    {
        get { return _GameState; }
        set { _GameState = value; OnChangeGameState.Invoke(value); }
    }

    [Header("GamePlay state objects")]
    public GameObject StartScreen;
    public GameObject Spawner;
    public GameObject GameToolSet;
    public GameObject MenuToolSet;
    public GameObject MainQuBit;

    public void OnEnable(){
        if(OnChangeGameState == null)
            OnChangeGameState = new UnityEvent<GameStateType>(); 

        Bootstrap();
    }

    public void Bootstrap(){
        Debug.Log("Bootstrap");
        GameState = GameStateType.Bootstrap;

        QuPoints = 0;

        Spawner.SetActive(false);
        GameToolSet.SetActive(false);
        MainQuBit.SetActive(false);

        StartScreen.SetActive(true);
        MenuToolSet.SetActive(true);

        
    }

    public void StartGame(){
        Debug.Log("Start Game");

        QuPoints = 0;

        StartScreen.SetActive(false);
        MenuToolSet.SetActive(false);

        Spawner.SetActive(true);
        GameToolSet.SetActive(true);
        MainQuBit.SetActive(true);

        MainQuBit.GetComponent<MainQuBit>().HealthDepleted.AddListener(FinishGame);

        
    }

    public void FinishGame(){
        Debug.Log("Finish game");

        Spawner.SetActive(false);
        GameToolSet.SetActive(false);

        MainQuBit.GetComponent<MainQuBit>().HealthDepleted.RemoveListener(FinishGame);
        MainQuBit.SetActive(false);

        StartScreen.SetActive(true);
        MenuToolSet.SetActive(true);

        GameState = GameStateType.FinishedGame;
    }

    public bool BuyQNode(Vector3 position, int cost = 15){
        if(QuPoints > cost){
            QuPoints -= cost;
            // TODO: Move instantiation to the tool
            GameObject qNode = Instantiate(QNodePrefab, position, Quaternion.identity);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int AddQPoints(int points = 0){
        QuPoints += points;
        HighScoreQuPoints += points;
        return QuPoints;
    }


    public void QuitGame(){
        Application.Quit();
    }




}
