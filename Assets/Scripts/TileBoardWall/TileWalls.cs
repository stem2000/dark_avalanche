using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWalls : MonoBehaviour
{
    [SerializeField] public Wall[] walls;
    public WallTypes[] wallTypesList;

    public Wall getWallPrefab(WallTypes wallIndex){ 
        return walls[(int)wallIndex];}


    public void wallTypesListInit(int size){ 
        wallTypesList = new WallTypes[size];}

}
