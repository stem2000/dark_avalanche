using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private Camera mainCamera;
    private Vector3 movement = Vector3.zero;


    public void Start() {
        mainCamera.transform.Rotate(new Vector3(55,0,0));
        transform.Rotate(new Vector3(0,30,0));}

    private void FixedUpdate(){
        Movement();}
    
    private void Movement(){ 
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");
        float correctMovHor = movHor;
        float correctMovVer = movVer;
        movement = new Vector3(correctMovHor,0.0f,correctMovVer);
        Debug.Log(movHor.ToString());
        transform.Translate(movement.normalized * Speed * Time.fixedDeltaTime);} }
