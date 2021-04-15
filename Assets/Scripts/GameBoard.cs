using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour{
    
    private Vector3Int boardSize; 
    [SerializeField] private int boardSizeX;
    [SerializeField] private int boardSizeY;
    [SerializeField] private Vector3 boardPosition; 
    [SerializeField] private int tileSize;
    [SerializeField] private Tile tilePrefab;
    private TileWalls wallsManager;
    private Transform boardTransform;
    private ArrayList tileList;
    private ArrayList wallsList;
    private string boardView;
    [HideInInspector]public RaycastHit hit;
    private Tile selectedTile;
    private Tile previousSelectedTile = null;


    public void boardInitialization(){
        initBoardTransform();
        initBoardSizeAndView();
        initBoardPosition();
        initVariables();}


    public void FixedUpdate() {
        choiceTileCheck();}

    
    private void initBoardScale(){ 
        boardTransform.localScale = new Vector3(tileSize*boardSize.x,tileSize*boardSize.z,1);}


    private void initBoardPosition(){ 
        boardTransform.position = boardPosition;}


    private void initBoardTransform(){ 
        boardTransform = this.transform;}


    private void initVariables(){
        wallsManager = GetComponent<TileWalls>();
        wallsManager.wallTypesListInit(4);
        tileList = new ArrayList();
        wallsList = new ArrayList();}


    public void tilesSelectionChange(){ 
        if(previousSelectedTile != null){ 
            previousSelectedTile.selected = false;}
        if(selectedTile != null){ 
            selectedTile.selected = true;}}


    private void initBoardSizeAndView(){ 
        boardSize = new Vector3Int(boardSizeX,0,boardSizeY);
        initBoardScale();
        boardView = "***W******"+
                    "W*********"+
                    "*******W**"+
                    "*S*****W**"+
                    "**********"+
                    "**********"+
                    "*W*****W**"+
                    "**********"+
                    "********D*"+
                    "**********";
        if(boardView.Length != boardSize.x*boardSize.z)
            Debug.Log("[boardView does no match the game board]");}


    public void createTileSet(){ 
        Tile initTile;
        Vector3 tileSPosition = new Vector3(boardPosition.x-boardSize.x*tileSize/2.0f+0.5f*tileSize, 0, boardPosition.z-boardSize.z*tileSize/2.0f+0.5f*tileSize);

        for(int iX = 0; iX < boardSize.x ;iX++) {
            for(int iZ = 0; iZ < boardSize.z; iZ++){
                    initTile = Instantiate(tilePrefab);
                    initTile.Start();
                    initTile.tileInitPosition(new Vector3(tileSPosition.x+iX*tileSize,0,tileSPosition.z+iZ*tileSize));
                    initTile.tileInitSize(tileSize);
                    initTile.initTileType(boardView[iX*boardSize.z + iZ]);
                    tileList.Add(initTile);
                    setTileLocatedObject(initTile);}}}


    public void choiceTileCheck(){ 
        if (Input.GetMouseButton(0)){
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)){
                if (hit.collider.gameObject.layer == 8){
                    previousSelectedTile = selectedTile;
                    selectedTile = hit.collider.gameObject.GetComponent<Tile>();
                    tilesSelectionChange();
                    Debug.Log("Selected tile - " + tileList.IndexOf(selectedTile).ToString());}}
            else{
                previousSelectedTile = selectedTile;
                selectedTile = null; 
                tilesSelectionChange();}}}


    public void setTileLocatedObject(Tile thisTile){ 
        switch(thisTile.tileType){ 
            case TileTypes.Wall:{
                Wall nWall = Instantiate(wallsManager.walls[(int)WallTypes.pineTree]);
                nWall.bindTile(thisTile);
                wallsList.Add(nWall);}
            break;}}
}


static class TMC{ 
    public const int DEFAULT_TILE_COLOR = 0; 
    public const int GREEN_TILE_COLOR = 1; 
    public const int YELLOW_TILE_COLOR = 2;
    public const char signWall = 'W';
    public const char signDestPoint = 'D';
    public const char signSpawn = 'S';
    public const char signFree = '*';}