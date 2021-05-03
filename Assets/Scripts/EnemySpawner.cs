using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] private Enemy enemyType;
    [SerializeField] private GameBoard gameBoard;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private int enemyNumber;
    private Enemy[] enemies;
    [SerializeField] private Timer timer;
    private int currentEnemyForSpawn;
    [HideInInspector] public Tile tileSpawn;

    private void Start() {
        currentEnemyForSpawn = 0;
        enemies = new Enemy[enemyNumber];
        timer = Instantiate(timer);
        for(int i = 0; i < enemyNumber;i++){ 
            enemies[i] = Instantiate(enemyType);
            enemies[i].gameObject.SetActive(false);}}


    public void spawnEnemy(Tile tileSpawn){ 
            enemies[currentEnemyForSpawn].gameObject.SetActive(true);
            enemies[currentEnemyForSpawn].initEnemy(tileSpawn); 
            currentEnemyForSpawn++;}
    
    
    public void FixedUpdate(){ 
        if(currentEnemyForSpawn < enemies.Length){ 
            if(timer.timerState() == Timer.stoped)
                timer.startTimer(spawnSpeed);} 
            if(timer.timerState() == Timer.ended){ 
                spawnEnemy(tileSpawn);
                timer.reactivateTimer();}}
    
    
    public Enemy[] getEnemiesSet(){ 
        return enemies;}}
