using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathBindSearch : MonoBehaviour
{

    public void bindTileRelations(Tile[] tileList, int boardSizeX,int boardSizeZ){ 
        for(int iX = 0; iX < boardSizeX ;iX++) {
            for(int iZ = 0; iZ < boardSizeZ; iZ++){ 

                if(iX + iZ - 1 > 0)
                    tileList[iX+iZ].leftTile = tileList[iX + iZ - 1];
                else 
                    tileList[iX+iZ].leftTile = null;

                if(iX + iZ + 1 < boardSizeX*boardSizeZ)
                    tileList[iX+iZ].rightTile = tileList[iX + iZ + 1];
                else 
                    tileList[iX+iZ].rightTile = null;

                if(iX + iZ + boardSizeX < boardSizeX*boardSizeZ)
                    tileList[iX+iZ].upperTile = tileList[iX + iZ + boardSizeX];
                else 
                    tileList[iX+iZ].upperTile = null;

                if(iX + iZ - boardSizeX > 0)
                    tileList[iX+iZ].lowerTile = tileList[iX + iZ - boardSizeX];
                else 
                    tileList[iX+iZ].lowerTile = null;}}}
}
