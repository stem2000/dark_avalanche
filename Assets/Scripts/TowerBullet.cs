using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [HideInInspector] public bool preparedForShoot = true;
    [HideInInspector] public bool shooted = false;
    [HideInInspector] public Enemy target = null;
    [SerializeField] private float bulletSpeed = 0;
    private Transform enemyTransform = null;
    [SerializeField] private float sizeCompensation;



    private void initTarget() {
        if(target != null)
            enemyTransform = target.transform;}


    public void initForShoot(Enemy target,Vector3 position){ 
        this.target = target;
        setStartPosition(position);
        setShootState();
        initTarget();}


    public void setScale(int tileSize){ 
        transform.localScale = transform.localScale * sizeCompensation * tileSize;}


    private void FixedUpdate(){
        if(enemyTransform != null)
            inShoot();}


    private void setShootState(){ 
        shooted = true;
        preparedForShoot = false;}


    private void setStartPosition(Vector3 position){
        transform.position = position;}

    private void inShoot(){ 
        if((transform.position - enemyTransform.position).magnitude < 1/bulletSpeed){ 
            shooted = false;
            preparedForShoot = true;
            gameObject.SetActive(false);}
        else 
            transform.Translate((enemyTransform.position-transform.position).normalized*bulletSpeed*Time.fixedDeltaTime);}
}
