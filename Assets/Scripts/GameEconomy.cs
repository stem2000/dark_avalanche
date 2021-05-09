using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEconomy : MonoBehaviour{
    [SerializeField] private int playerMoney;


    public void getMoneyFromObject(int money){ 
        playerMoney+=money;}

    public bool spendMoneyToObject(int money){ 
        if(playerMoney - money >= 0){ 
            playerMoney -= money;
            return true;}
        else 
            return false;}
}
