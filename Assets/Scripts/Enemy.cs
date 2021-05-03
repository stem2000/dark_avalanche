using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private EnemyMovement enMov;
    private EnemyStats enStats;
    private bool initFlag = false;


    public void initVariables(){ 
        enMov = GetComponent<EnemyMovement>();
        enStats = GetComponent<EnemyStats>();}


    public void initEnemy(Tile startTile){
        initVariables();
        enMov.initMovElement(startTile);
        initFlag = true;}


    public void FixedUpdate() {
        if(initFlag){
            enMov.walking();}}
}
