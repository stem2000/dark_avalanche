using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
     private AudioSource audioSource;
    [SerializeField] private AudioClip onClickClip;
    void Start(){
        audioSource = GetComponent<AudioSource>();}



    public void ExitGame(){ 
        audioSource.PlayOneShot(onClickClip);
        Application.Quit();}

}
