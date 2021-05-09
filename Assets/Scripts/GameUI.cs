using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]public Text moneyText;
    public Text defensePoints;
    [HideInInspector] public string startMoneyText;
    [HideInInspector] public string startDefenseText;

    private void Start() {
        startMoneyText = moneyText.text;
        startDefenseText = defensePoints.text;}
    
}
