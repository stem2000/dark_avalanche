using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{

    [SerializeField] private float radius;
    public float sizeCompensation;
    Collider[] collidersEnemy = new Collider[1];
    private Enemy currentTarget;
    private bool targetIsActive = false;
    public int enemiesLayerMask = 1 << 9;

    void Start(){
        collidersEnemy = new Collider[1];}


    private void FixedUpdate() {
        if(!targetIsActive)
            targetSearch();
        if(targetIsActive)
            attackTarget();}


    private void targetSearch(){
            int trigger = Physics.OverlapSphereNonAlloc(transform.localPosition,radius,collidersEnemy,enemiesLayerMask);    
            if(trigger != 0){ 
                Debug.Log("+Target");
                targetIsActive = true;
                currentTarget = collidersEnemy[0].gameObject.GetComponent<Enemy>();}}


    private void attackTarget(){ 
        Vector3 direction = transform.position - currentTarget.transform.position;
        if(direction.magnitude < radius){}
        else{ 
            targetIsActive = false;}}
}
