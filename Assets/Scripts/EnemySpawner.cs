using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] private EnemyWave[] enemyWaves;
    [SerializeField] private Enemy enemyType;
    [SerializeField] private GameBoard gameBoard;
    private int enemiesMaxNumber = 0;
    private float spawnSpeedForWave;
    [HideInInspector] public GameEconomy gameEconomy;
    private Enemy[] enemies;
    [SerializeField] private Timer timerSpawn;
    [SerializeField] private Timer timerWaves;
    private int currentWave;
    private int timeAfterWave = 0;
    private int currentEnemyForSpawn;
    [HideInInspector] public Tile tileSpawn;


    private void Start() {

        currentWave = 0;
        currentEnemyForSpawn = 0;

        setMaxEnemieNumber();

        setSpawnerFromWaveInfo(enemyWaves[currentWave]);

        enemies = new Enemy[enemiesMaxNumber];

        timerSpawn = Instantiate(timerSpawn);
        timerWaves = Instantiate(timerWaves);

        for(int i = 0; i < enemiesMaxNumber;i++){ 
            enemies[i] = Instantiate(enemyType);
            enemies[i].initVariables();
            enemies[i].gameObject.SetActive(false);}}


    public void spawnEnemy(Tile tileSpawn){ 
            enemies[currentEnemyForSpawn].gameObject.SetActive(true);
            enemies[currentEnemyForSpawn].setStats(enemyWaves[currentWave]);
            enemies[currentEnemyForSpawn].initEnemy(tileSpawn,this); 
            currentEnemyForSpawn++;}
    

    public void returnMoney(int money){ 
        gameEconomy.getMoneyFromObject(money);}
    

    public void FixedUpdate(){ 
        if(allEnemiesBorn()){
            timerWaves.startTimer(timeAfterWave);
            if(timerWaves.timerState() == Timer.ended){
                if(currentWave < enemyWaves.Length)
                    currentWave++;
                setSpawnerFromWaveInfo(enemyWaves[currentWave]); 
                timerWaves.reactivateTimer();}}
        if(currentEnemyForSpawn < enemyWaves[currentWave].enemyNumber){ 
            timerSpawn.startTimer(spawnSpeedForWave); 
            if(timerSpawn.timerState() == Timer.ended){ 
                spawnEnemy(tileSpawn);
                timerSpawn.reactivateTimer();}}}
    

    private void setMaxEnemieNumber(){ 
        for( int i = 0; i < enemyWaves.Length; i++){ 
            if(enemyWaves[i].enemyNumber > enemiesMaxNumber){ 
                enemiesMaxNumber = enemyWaves[i].enemyNumber;}}}


    private bool allEnemiesBorn(){
        if(currentEnemyForSpawn == enemyWaves[currentWave].enemyNumber && AllEnemiesFalse()){
            return true;}
        return false;}


    private bool AllEnemiesFalse(){ 
        for(int i = 0; i < enemyWaves[currentWave].enemyNumber; i++){ 
            if(enemies[i].gameObject.activeSelf)
                return false;}
        return true;}


    private void setSpawnerFromWaveInfo(EnemyWave enWave){ 
        currentEnemyForSpawn = 0;
        spawnSpeedForWave = enWave.enemySpawnSpeed;
        timeAfterWave = enWave.timeAfterWave;}


    public Enemy[] getEnemiesSet(){ 
        return enemies;}}




[System.Serializable]
public class EnemyWave{
    public int enemyNumber = 0;
    public int enemySpeed = 0;
    public int enemyHP = 0;
    public float enemySpawnSpeed = 0;
    public Vector3 Scale = Vector3.zero;
    public int timeAfterWave = 0;}
