using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEconomy : MonoBehaviour{
    [SerializeField] private int playerMoney = 0;
    [SerializeField] private int defensePoints = 0;


    public void getMoneyFromObject(int money){ 
        playerMoney+=money;}


    public bool spendMoneyToObject(int money){ 
        if(playerMoney - money >= 0){ 
            playerMoney -= money;
            return true;}
        else 
            return false;}


    public int moneyInfo(){ 
        return playerMoney;}


    public int dPointsInfo(){ 
        return defensePoints;}


}
