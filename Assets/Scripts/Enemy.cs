using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [HideInInspector] public Tile startTile;
    private Tile nextTile;
    public float speed = 3;
    float StartDelay;
    float Delay;
    public void startTileInit(Tile startTile){ 
            this.startTile = startTile;
            nextTile = startTile.tileDirection;
            if(nextTile == null)
                Debug.Log("agada");}


    public void startTPosition(Tile startTile){ 
            transform.position = startTile.transform.position;
            Delay = StartDelay = 2;}


    public void initEnemy(Tile startTile){ 
            startTileInit(startTile);
            startTPosition(startTile);}


    public void tileChange(){ 
        if(nextTile.tileDirection != null)
            nextTile = nextTile.tileDirection.tileDirection;}


    public void walking(){ 
        transform.position = nextTile.transform.position;
        tileChange();}


    public void FixedUpdate() {
        if (this.Delay > 0) 
            this.Delay -= Time.fixedDeltaTime;
        else { 
            walking();
            this.RefreshDelay();}}

    void RefreshDelay() {
        this.Delay = this.StartDelay;}

}
