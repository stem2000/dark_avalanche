using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
   [SerializeField] private TowerBullet towerBullet;
   [SerializeField] private Timer timer;
   [HideInInspector] public Tower thisTower;
   [SerializeField] private int startBulletsCount;
   [SerializeField] private float attackSpeed;
   private TowerBullet[] bulletsList;
   

    private void Start() {
        thisTower = GetComponent<Tower>();
        bulletsList = new TowerBullet[startBulletsCount];
        timer = Instantiate(timer);
        for(int i = 0; i < startBulletsCount;i++){ 
            bulletsList[i] = Instantiate(towerBullet);
            bulletsList[i].setScale(thisTower.connectedTile.size);
            bulletsList[i].gameObject.SetActive(false);}}


    public void Attack(){ 
        int iterMem = 0;
        for(; iterMem < bulletsList.Length;iterMem++){ 
            if(bulletsList[iterMem].preparedForShoot == true){
                bulletsList[iterMem].gameObject.SetActive(true);
                bulletsList[iterMem].initForShoot(thisTower.getFocusEnemy(),transform.position + new Vector3(0,2,0));
                break; }}}


    public void FixedUpdate() {
            timer.startTimer(attackSpeed);
            if(timer.timerState() == Timer.ended){ 
                if(thisTower.isTriggered())
                    Attack();
                timer.reactivateTimer();}}
}
