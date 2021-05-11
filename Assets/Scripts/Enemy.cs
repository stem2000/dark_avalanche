using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private EnemyMovement enMov;
    [HideInInspector] public EnemyStats enStats;
    public EnemySpawner mySpawner;
    [HideInInspector] public bool deathState;
    [SerializeField] Timer timerForAnimation;
    private bool initFlag = false;


    public void initVariables(){ 
        enMov = GetComponent<EnemyMovement>();
        enStats = GetComponent<EnemyStats>();}


    public void initEnemy(Tile startTile, EnemySpawner spawner){
        enMov.initMovElement(startTile);
        mySpawner = spawner;
        initFlag = true;
        deathState = false;}


    public void getDamage(int damage){ 
        enStats.HP-=damage;}


    public void giveMoneyToSpawner(){ 
        mySpawner.returnMoney(Random.Range(enStats.costLowerBound,enStats.costUpperBound));}


    public void reduceDefensePoints(){ 
        mySpawner.gameEconomy.reduceDefensePoints(1);}


    public void setStats(EnemyWave statsObj){ 
        if(statsObj.enemyHP != 0)
            enStats.HP = statsObj.enemyHP;
        if(statsObj.enemySpeed != 0)
            enStats.Speed = statsObj.enemySpeed;
        if(statsObj.enemySpeed != 0)
            enStats.Speed = statsObj.enemySpeed;
        if(statsObj.enemySpeed != 0)
            enStats.Speed = statsObj.enemySpeed;
        if(statsObj.Scale != Vector3.zero)
            transform.localScale = statsObj.Scale;}


    public void FixedUpdate() {
        if(initFlag){
            enMov.walking();}
        if(enStats.HP <= 0 && initFlag == true){ 
            enMov.enemyFalling();
            giveMoneyToSpawner();
            initFlag = false;
            gameObject.SetActive(false);}}
}
