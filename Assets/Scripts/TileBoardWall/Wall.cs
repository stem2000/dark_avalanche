using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour{
    [HideInInspector]public Tile wallTile;
    private WallTypes wallType;
    [SerializeField] float sizeCompensation;


    public void Start() {
        sizeCompensation = 0.8f;}

    public void bindTile(Tile tileToBind){ 
        wallTile = tileToBind;
        transform.position = tileToBind.transform.position;
        transform.localScale = transform.localScale*tileToBind.size*sizeCompensation;}}

public enum WallTypes{
        pineTree}