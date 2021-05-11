using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] private EnemyWave[] enemyWaves;
    [SerializeField] private Enemy enemyType;
    [SerializeField] private GameBoard gameBoard;
    private float spawnSpeedForWave;
    [SerializeField] private int enemyNumber;
    [HideInInspector] public GameEconomy gameEconomy;
    private Enemy[] enemies;
    [SerializeField] private Timer timerSpawn;
    [SerializeField] private Timer timerWaves;
    private int currentEnemyForSpawn;
    [HideInInspector] public Tile tileSpawn;

    private void Start() {
        currentEnemyForSpawn = 0;
        enemies = new Enemy[enemyNumber];
        timerSpawn = Instantiate(timerSpawn);
        timerWaves = Instantiate(timerWaves);
        for(int i = 0; i < enemyNumber;i++){ 
            enemies[i] = Instantiate(enemyType);
            enemies[i].gameObject.SetActive(false);}}


    public void spawnEnemy(Tile tileSpawn){ 
            enemies[currentEnemyForSpawn].gameObject.SetActive(true);
            enemies[currentEnemyForSpawn].initEnemy(tileSpawn,this); 
            currentEnemyForSpawn++;}
    

    public void returnMoney(int money){ 
        gameEconomy.getMoneyFromObject(money);}
    

    public void FixedUpdate(){ 
        if(currentEnemyForSpawn < enemies.Length){ 
            if(timerSpawn.timerState() == Timer.stoped)
                timerSpawn.startTimer(spawnSpeedForWave);} 
            if(timerSpawn.timerState() == Timer.ended){ 
                spawnEnemy(tileSpawn);
                timerSpawn.reactivateTimer();}}
    
    
    public Enemy[] getEnemiesSet(){ 
        return enemies;}}




[System.Serializable]
public class EnemyWave{
    public int enemyNumber = 0;
    public int enemySpeed = 0;
    public int enemyHP = 0;
    public int enemySpawnSpeed = 0;
    public Vector3 Scale = Vector3.zero;
    public int timeAfterWave = 0;}
