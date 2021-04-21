using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard board;
    [SerializeField] private EnemySpawner enemySpawner;
    
    void Start(){
        board.boardInitialization();
        board.createTileSet(); 
        board.initTilesRelations();
        board.pathBuilding();
        enemySpawner.spawnEnemy(board.getSpawnTile());}


    void Update(){
        
    }
}
