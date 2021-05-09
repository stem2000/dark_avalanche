using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{

    [SerializeField] private float radius;
    [HideInInspector] private TowerStats towerStats;
    public float sizeCompensation;
    [HideInInspector] public Tile connectedTile = null;
    public bool towerSelectedByPlayer = false;
    Collider[] collidersEnemy = new Collider[1];
    private Enemy currentTarget;
    private bool targetIsActive = false;
    public int enemiesLayerMask = 1 << 9;


    void Start(){
        collidersEnemy = new Collider[1];
        towerStats = GetComponent<TowerStats>();}


    public int towerCost(){ 
        return towerStats.cost;}


    public bool isTriggered(){ 
        return targetIsActive;}


    public Enemy getFocusEnemy(){ 
        if(targetIsActive)
            return currentTarget;
        return null;}


    private void FixedUpdate() {
        if(!targetIsActive)
            targetSearch();
        if(!targetIsAvailable())
            targetIsActive = false;}


    private void targetSearch(){
            int trigger = Physics.OverlapSphereNonAlloc(transform.localPosition,radius,collidersEnemy,enemiesLayerMask);    
            if(trigger != 0){ 
                targetIsActive = true;
                currentTarget = collidersEnemy[0].gameObject.GetComponent<Enemy>();}}
    

    private bool targetIsAvailable(){ 
        if(targetIsActive == false) return false;
        if((transform.position - currentTarget.transform.position).magnitude > radius || currentTarget.deathState)
            return false;
        return true;}}
