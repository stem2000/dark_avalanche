using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
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


    public void setStartTPosition(Tile startTile){ 
            transform.position = startTile.transform.position;
            transform.position = new Vector3(transform.position.x,transform.position.y+0.2f,transform.position.z);}


    public void initMovElement(Tile startTile){ 
            startTileInit(startTile);
            setStartTPosition(startTile);
            setDirection();
            setRotation();
            initVariables();}


    public void initVariables(){ 
        rB = GetComponent<Rigidbody>();
        skeletAnim = GetComponent<Animator>();}


    public void tileChange(){ 
        if(nextTile.tileDirection != null)
            nextTile = nextTile.tileDirection;
        else if(nextTile.tileType == TileTypes.DestPoint){ 
                speed = 0;
                gameObject.SetActive(false);}
        else{ 
            speed = 0;}}


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
            setRotation();}}}
