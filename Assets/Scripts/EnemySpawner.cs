using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] private Enemy skileton;
    [SerializeField] private GameBoard gameBoard;

    public void spawnEnemy(Tile tileSpawn){ 
        Instantiate(skileton).initEnemy(tileSpawn);}}
