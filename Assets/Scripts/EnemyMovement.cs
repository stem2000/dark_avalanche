using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public Tile startTile;
    [SerializeField] private Vector3 plusYpos = new Vector3(0,0.2f,0);
    private Tile nextTile;
    private Tile prevTile;
    public float speed = 3;
    private Vector3 direction;
    private Rigidbody rB;
    private Animator skeletAnim;
    private Enemy enemyThis;
    private BoxCollider enemyCollider;



    public void startTileInit(Tile startTile){ 
            this.startTile = startTile;
            prevTile = nextTile = startTile.tileDirection;}


    public void setStartTPosition(Tile startTile){ 
            transform.position = startTile.transform.position;
            transform.position = new Vector3(transform.position.x,transform.position.y+plusYpos.y,transform.position.z);}


    public void initMovElement(Tile startTile){ 
            startTileInit(startTile);
            setStartTPosition(startTile);
            setDirection();
            setRotation();
            initVariables();}


    public void initVariables(){ 
        rB = GetComponent<Rigidbody>();
        skeletAnim = GetComponent<Animator>();
        enemyThis = GetComponent<Enemy>();
        enemyCollider = GetComponent<BoxCollider>();
        enemyCollider.enabled = true;}


    public void tileChange(){ 
        if(nextTile.tileDirection != null){
            nextTile = nextTile.tileDirection;}
        else if(nextTile.tileType == TileTypes.DestPoint){ 
                speed = 0;
                enemyThis.deathState = true;
                enemyThis.reduceDefensePoints();
                gameObject.SetActive(false);}}


    public void setDirection(){ 
            direction = nextTile.transform.position - transform.position;}


    public void setRotation(){ 
            transform.rotation = Quaternion.LookRotation(direction);}


    public void walking(){ 
        rB.velocity = direction.normalized*speed;
        skeletAnim.Play("Walk");
        if(nextTile == null){ 
            searchAlternativePath();}
        if((nextTile.transform.position - transform.position - plusYpos).magnitude < Mathf.Sqrt((nextTile.size)*(nextTile.size))/2){
            tileChange(); 
            setDirection();
            setRotation();}}
    
    
    public void enemyFalling(){ 
        speed = 0;
        enemyThis.deathState = true;
        enemyCollider.enabled = false;
        skeletAnim.StopPlayback();
        skeletAnim.Play("Death");}
    
    
    private void OnCollisionEnter(Collision collision){ 
        if(collision.gameObject.layer == 10){ 
                searchAlternativePath();}}
    
    
    private void searchAlternativePath(){ 
        if(nextTile != null){ 
            if(nextTile.leftTile != null && nextTile.leftTile.tileType == TileTypes.Free && nextTile.leftTile.tileDirection != null){ 
                setStartTPosition(nextTile.leftTile);
                nextTile = nextTile.leftTile.tileDirection;
                setDirection();
                setRotation();
                return;}
            if(nextTile.rightTile != null && nextTile.rightTile.tileType == TileTypes.Free && nextTile.rightTile.tileDirection != null){ 
                setStartTPosition(nextTile.rightTile);
                nextTile = nextTile.rightTile.tileDirection;
                setDirection();
                setRotation();
                return;}
            if(nextTile.upperTile != null && nextTile.upperTile.tileType == TileTypes.Free && nextTile.upperTile.tileDirection != null){ 
                setStartTPosition(nextTile.upperTile);
                nextTile = nextTile.upperTile.tileDirection;
                setDirection();
                setRotation();
                return;}
            if(nextTile.lowerTile != null && nextTile.lowerTile.tileType == TileTypes.Free && nextTile.lowerTile.tileDirection != null){ 
                setStartTPosition(nextTile.lowerTile);
                nextTile = nextTile.lowerTile.tileDirection;
                setDirection();
                setRotation();
                return;}}
        setStartTPosition(startTile);
        nextTile = startTile;
        setDirection();
        setRotation();}}
