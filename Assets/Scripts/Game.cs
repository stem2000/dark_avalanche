using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard board;
    [SerializeField] TowerBuilding towerBuilder;
    [SerializeField] private EnemySpawner[] enemySpawners;
    [HideInInspector] private GameEconomy gameEconomy;
    

    void Start(){
        gameEconomy = GetComponent<GameEconomy>();
        board.boardInitialization();
        board.createTileSet(); 
        board.initTilesRelations();
        board.pathBuilding();
        towerBuilder.board = board;
        board.towerBuilder = towerBuilder;
        spawnerStartTileInit();
        setGameEconomyObjects();}


    void spawnerStartTileInit(){ 
        for(int i = 0; i < enemySpawners.Length; i++){ 
            enemySpawners[i].tileSpawn = board.getSpawnTile();}}

    void setGameEconomyObjects(){ 
        towerBuilder.gameEconomy = gameEconomy;
        for(int i = 0; i < enemySpawners.Length;i++){ 
            enemySpawners[i].gameEconomy = gameEconomy;}}




}
