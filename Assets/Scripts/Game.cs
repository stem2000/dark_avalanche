using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard board;
    
    void Start(){
        board.boardInitialization();
        board.createTileSet();}


    void Update(){
        
    }
}
