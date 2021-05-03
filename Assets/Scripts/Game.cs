using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard board;
    [SerializeField] TowerBuilding towerBuilder;
    [SerializeField] private EnemySpawner[] enemySpawners;
    

    void Start(){
        board.boardInitialization();
        board.createTileSet(); 
        board.initTilesRelations();
        board.pathBuilding();
        towerBuilder.board = board;
        spawnerStartTileInit();}


    void spawnerStartTileInit(){ 
        for(int i = 0; i < enemySpawners.Length; i++){ 
            enemySpawners[i].tileSpawn = board.getSpawnTile();}}




}
