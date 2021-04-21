using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [HideInInspector] public Tile startTile;
    private Tile nextTile;
    public float speed = 3;
    private Vector3 direction;
    private Rigidbody rB;
    private Animator skeletAnim;
    public void startTileInit(Tile startTile){ 
            this.startTile = startTile;
            nextTile = startTile.tileDirection;}


    public void startTPosition(Tile startTile){ 
            transform.position = startTile.transform.position;
            transform.position = new Vector3(transform.position.x,transform.position.y+0.2f,transform.position.z);}


    public void initEnemy(Tile startTile){ 
            startTileInit(startTile);
            startTPosition(startTile);
            setDirection();
            setRotation();
            initVariables();}


    public void initVariables(){ 
        rB = GetComponent<Rigidbody>();
        skeletAnim = GetComponent<Animator>();}


    public void tileChange(){ 
        if(nextTile.tileDirection != null)
            nextTile = nextTile.tileDirection;}


    public void setDirection(){ 
            direction = nextTile.transform.position - transform.position;}

    public void setRotation(){ 
            transform.rotation = Quaternion.LookRotation(direction);}

    public void walking(){ 
        rB.velocity = direction.normalized*speed;
        skeletAnim.Play("Walk");
        if((nextTile.transform.position - transform.position).magnitude < Mathf.Sqrt((nextTile.size)*(nextTile.size))/2){
            tileChange(); 
            setDirection();
            setRotation();}}


    public void FixedUpdate() {
            walking();}


}
