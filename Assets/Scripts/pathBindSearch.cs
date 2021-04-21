using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBindSearch : MonoBehaviour{

    private List<Tile> destinationTiles = new List<Tile>();
    private List<Tile> tilesQueue = new List<Tile>();


    public void bindTileRelations(Tile[] tileList, int boardSizeX,int boardSizeZ){ 

        for(int iX = 0; iX < boardSizeX*boardSizeZ ;iX++) {

                if(iX - 1 > 0)
                    tileList[iX].leftTile = tileList[iX - 1];
                else {
                    tileList[iX].leftTile = null;}

                if(iX + 1 < boardSizeX*boardSizeZ)
                    tileList[iX].rightTile = tileList[iX + 1];
                else 
                    tileList[iX].rightTile = null;

                if(iX + boardSizeX < boardSizeX*boardSizeZ)
                    tileList[iX].upperTile = tileList[iX + boardSizeX];
                else 
                    tileList[iX].upperTile = null;

                if(iX - boardSizeX > 0)
                    tileList[iX].lowerTile = tileList[iX - boardSizeX];
                else 
                    tileList[iX].lowerTile = null;}}


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


            if(rightT != null && rightT.searchState == false){ 
                rightT.tileDirection = rightT.leftTile;
                rightT.searchState = true;
                tilesQueue.Add(rightT);}

            if(upperT != null && upperT.searchState == false){ 
                upperT.tileDirection = upperT.lowerTile;
                upperT.searchState = true;
                tilesQueue.Add(upperT);}

            if(leftT != null && leftT.searchState == false){ 
                leftT.tileDirection = leftT.rightTile;
                leftT.searchState = true;
                tilesQueue.Add(leftT);}

            if(lowerT != null && lowerT.searchState == false){ 
                lowerT.tileDirection = lowerT.upperTile;
                lowerT.searchState = true;
                tilesQueue.Add(lowerT);}

            tilesQueue.RemoveAt(0);}}
}
