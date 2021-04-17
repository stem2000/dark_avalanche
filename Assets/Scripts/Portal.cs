using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour{
  [HideInInspector]public Tile portalTile;
    
    public void bindTile(Tile tileToBind){ 
        portalTile = tileToBind;
        transform.position = tileToBind.transform.position;
        transform.position = new Vector3(transform.position.x,1,transform.position.z);}}
