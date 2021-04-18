using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private float rotationSpeed = 3.0f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameBoard gameBoard;
    private Vector3 movement = Vector3.zero;


    public void Start() {
        mainCamera.transform.Rotate(new Vector3(55,0,0));
        transform.Rotate(new Vector3(0,30,0));}



    private void FixedUpdate(){
        Movement();
        Rotation();}
    

    private void Movement(){ 
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");
        movement = new Vector3(movHor,0.0f,movVer);
        if((transform.position - gameBoard.transform.position + movement.normalized).magnitude < gameBoard.size*4){
            transform.Translate(movement.normalized * Speed * Time.fixedDeltaTime); }
        else{
            transform.position = new Vector3(
                transform.position.x - transform.position.x / Mathf.Abs(transform.position.x)*0.1f,
                transform.position.y,
                transform.position.z - transform.position.z / Mathf.Abs(transform.position.z)*0.1f);}}
    
    
    public void Rotation(){ 
        float rotHor = Input.GetAxis("CameraRotationAxis"); 
        float signRotation = 0;
        if(rotHor > 0)
            signRotation = 1;
        else if(rotHor < 0)
            signRotation = - 1;
        else if(rotHor == 0)
            signRotation = 0;
        transform.RotateAround(gameBoard.transform.position,new Vector3(0,1,0),signRotation*rotationSpeed);}}
