using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private EnemyMovement enMov;
    private EnemyStats enStats;
    public EnemySpawner mySpawner;
    private bool initFlag = false;


    public void initVariables(){ 
        enMov = GetComponent<EnemyMovement>();
        enStats = GetComponent<EnemyStats>();}


    public void initEnemy(Tile startTile, EnemySpawner spawner){
        initVariables();
        enMov.initMovElement(startTile);
        mySpawner = spawner;
        initFlag = true;}


    public void getDamage(int damage){ 
        enStats.HP-=damage;}


    public void giveMoneyToSpawner(){ 
        mySpawner.returnMoney(Random.Range(enStats.costLowerBound,enStats.costUpperBound));}


    public void FixedUpdate() {
        if(initFlag){
            enMov.walking();}
        if(enStats.HP <= 0){ 
            enMov.enemyFalling();
            giveMoneyToSpawner();
            initFlag = false;}}
}
