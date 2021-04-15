using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour{
    [HideInInspector]public Tile wallTile;
    private WallTypes wallType;
    
    public void bindTile(Tile tileToBind){ 
        wallTile = tileToBind;
        transform.position = tileToBind.transform.position;
        transform.localScale = transform.localScale*tileToBind.size;}}

public enum WallTypes{
        pineTree}