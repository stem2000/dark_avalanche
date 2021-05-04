using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBindSearch : MonoBehaviour{

    private List<Tile> destinationTiles = new List<Tile>();
    private List<Tile> tilesQueue = new List<Tile>();


    public void bindTileRelations(Tile[] tileList, int boardSizeX,int boardSizeZ){ 

        for(int iX = 0; iX < boardSizeX; iX++){ 
            for(int iZ = 0; iZ < boardSizeZ-1; iZ++){ 
                    tileList[iX*boardSizeZ+iZ].upperTile = tileList[iX*boardSizeZ+iZ + 1];
                    tileList[iX*boardSizeZ+iZ].upperTileInt = iX*boardSizeZ+iZ + 1;}}
        
        for(int iX = 0; iX < boardSizeX; iX++){ 
            for(int iZ = boardSizeZ - 1; iZ > 0; iZ--){ 
                    tileList[iX*boardSizeZ+iZ].lowerTile = tileList[iX*boardSizeZ+iZ - 1];
                    tileList[iX*boardSizeZ+iZ].lowerTileInt = iX*boardSizeZ+iZ - 1;}}
        
        for(int iZ = 0; iZ < boardSizeZ; iZ++){ 
            for(int iX = 0; iX < boardSizeX-1; iX++){ 
                    tileList[iX*boardSizeZ+iZ].rightTile = tileList[(iX+1)*boardSizeZ+iZ];
                    tileList[iX*boardSizeZ+iZ].rightTileInt = (iX+1)*boardSizeZ+iZ;}}
        
        for(int iZ = 0; iZ < boardSizeZ; iZ++){ 
            for(int iX = boardSizeX - 1; iX > 0; iX--){ 
                    tileList[iX*boardSizeZ+iZ].leftTile = tileList[(iX-1)*boardSizeZ+iZ];
                    tileList[iX*boardSizeZ+iZ].leftTileInt = (iX-1)*boardSizeZ+iZ;}}}


    public void findDestPoint(Tile[] tileList){ 
            for(int i = 0; i < tileList.Length; i++){ 
                if(tileList[i].tileType == TileTypes.DestPoint)
                    destinationTiles.Add(tileList[i]);}}


    public void BFS(Tile[] tileList){
        Tile leftT;
        Tile rightT;
        Tile upperT;
        Tile lowerT;
        Tile startFP;

        startFP = destinationTiles[0];
        startFP.searchState = true;
        tilesQueue.Add(startFP);

        while(tilesQueue.Count != 0){ 

            rightT = tilesQueue[0].rightTile;
            upperT = tilesQueue[0].upperTile;
            leftT = tilesQueue[0].leftTile;
            lowerT = tilesQueue[0].lowerTile;


            if(rightT != null && rightT.searchState == false && rightT.tileType != TileTypes.Wall){ 
                rightT.tileDirection = tilesQueue[0];
                //rightT.transform.Rotate(new Vector3(0,90,0));
                rightT.searchState = true;
                tilesQueue.Add(rightT);}

            if(upperT != null && upperT.searchState == false && upperT.tileType != TileTypes.Wall){ 
                upperT.tileDirection = tilesQueue[0];
                //upperT.transform.Rotate(new Vector3(0,180,0));
                upperT.searchState = true;
                tilesQueue.Add(upperT);}

            if(leftT != null && leftT.searchState == false && leftT.tileType != TileTypes.Wall){ 
                leftT.tileDirection = tilesQueue[0];
                //leftT.transform.Rotate(new Vector3(0,-90,0));
                leftT.searchState = true;
                tilesQueue.Add(leftT);}

            if(lowerT != null && lowerT.searchState == false && lowerT.tileType != TileTypes.Wall){ 
                lowerT.tileDirection = tilesQueue[0];
                //lowerT.transform.Rotate(new Vector3(0,180,0));
                lowerT.searchState = true;
                tilesQueue.Add(lowerT);}

            tilesQueue.RemoveAt(0);}}


    public void reactivateTilesState(Tile[] tileList){ 
        for(int i = 0; i < tileList.Length;i++){ 
            tileList[i].searchState = false;
            tileList[i].tileDirection = null;}}
}
