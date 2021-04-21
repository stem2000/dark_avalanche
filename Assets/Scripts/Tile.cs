using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Transform tileTransform;

    public Tile upperTile;
    public Tile lowerTile;
    public Tile leftTile;
    public Tile rightTile;

    public int upperTileInt;
    public int lowerTileInt;
    public int leftTileInt;
    public int rightTileInt;

    public Tile tileDirection;
    public bool searchState;
    [HideInInspector] public TileTypes tileType;
    private int tileMaterial;
    private int tileSize;
    private bool isSelected;
    public int tileIndex;
    [SerializeField] Material[] tileMaterials;


    public void FixedUpdate() { 
            materialControl();}

    public void tileInitSize(int size){ 
        tileSize = size;
        tileTransform.localScale = new Vector3(tileSize,0.1f,tileSize);}

    public void tileInitPosition(Vector3 tilePosition){ 
        tileTransform.position = tilePosition;} 


    public void tileInitVariables(){ 
        upperTile = lowerTile = leftTile = rightTile = null;
        upperTileInt = lowerTileInt = leftTileInt = rightTileInt = -1;
        tileTransform = transform;
        isSelected = false;
        searchState = false;}

    public void initTileType(char typeSign){ 
        switch(typeSign){ 

            case TMC.signWall:
                tileType = TileTypes.Wall;
                break;

            case TMC.signSpawn:
                tileType = TileTypes.Spawn;
                break;

            case TMC.signDestPoint:
                tileType = TileTypes.DestPoint;
                break;
                
            case TMC.signFree:
                tileType = TileTypes.Free;
                break;}}



    public int material{
        set{
            tileMaterial = value;
            GetComponent<MeshRenderer>().material = tileMaterials[tileMaterial];}}


    public int size{
        get{
            return tileSize;}}


    public bool selected{
        set{
            isSelected = value;}}


    private void materialControl(){ 

        if(!isSelected && tileMaterial != TMC.DEFAULT_TILE_COLOR){
            tileMaterial = TMC.DEFAULT_TILE_COLOR;
            material = tileMaterial;}

        if((isSelected && tileMaterial != TMC.GREEN_TILE_COLOR) && tileType == TileTypes.Free){
            tileMaterial = TMC.GREEN_TILE_COLOR;
            material = tileMaterial;}
        
        if(isSelected && tileType != TileTypes.Free){
            tileMaterial = TMC.YELLOW_TILE_COLOR;
            material = tileMaterial;}}

}


public enum TileTypes{ 
    Spawn,
    DestPoint,
    Wall,
    Free}