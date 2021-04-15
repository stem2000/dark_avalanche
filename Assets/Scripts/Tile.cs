using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Transform tileTransform;

    public enum TileTypes{ 
        Spawn,
        DestPoint,
        Wall,
        Free}

    private Tile upperTile;
    private Tile lowerTile;
    private Tile leftTile;
    private Tile rightTile;
    private TileTypes tileType;
    private int tileMaterial;
    private int tileSize;
    private bool isSelected;
    [SerializeField] Material[] tileMaterials;

    public void Start() {
        tileTransform = transform;
        upperTile = lowerTile = leftTile = rightTile = null;
        isSelected = false;}


     public void FixedUpdate() { 
            materialControl();}

     public void tileInitSize(int size){ 
        tileSize = size;
        tileTransform.localScale = new Vector3(tileSize,0.1f,tileSize);}

    public void tileInitPosition(Vector3 tilePosition){ 
        tileTransform.position = tilePosition;} 


     public TileTypes type{
        get{
            return tileType;}
        set{
            tileType = value;}}


    public int material{
        set{
            tileMaterial = value;
            GetComponent<MeshRenderer>().material = tileMaterials[tileMaterial];}}


    public bool selected{
        set{
            isSelected = value;}}


    private void materialControl(){ 

        if(!isSelected && tileMaterial != TMC.DEFAULT_TILE_COLOR){
            tileMaterial = TMC.DEFAULT_TILE_COLOR;
            material = tileMaterial;}

        if(isSelected && tileMaterial != TMC.GREEN_TILE_COLOR){
            tileMaterial = TMC.GREEN_TILE_COLOR;
            material = tileMaterial;}}

}
