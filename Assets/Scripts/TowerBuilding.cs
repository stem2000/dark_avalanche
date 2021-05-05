using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : MonoBehaviour
{
    [HideInInspector] public GameBoard board;
    private int tileSize;
    [SerializeField] private Tower tower;
    [HideInInspector] public Tower selectedTower = null;
    private void Start() {}

    private void Update(){
        checkPlayerKeys();}


    private void checkPlayerKeys(){ 
        Tile selectedTile = board.getSelectedTile();
        Tower newTower = null;

        if(selectedTile == null)
            return;

        if(Input.GetKeyDown(KeyCode.T) && board.getSelectedTile().tileType == TileTypes.Free){ 
            newTower = Instantiate(tower);
            newTower.transform.position = board.getSelectedTile().transform.position;
            newTower.transform.localScale =  newTower.transform.localScale*selectedTile.size*newTower.sizeCompensation;
            newTower.connectedTile = selectedTile;
            selectedTile.tileType = TileTypes.Wall;
            board.takeOffSelection();
            board.pathBuilding();}}
}
