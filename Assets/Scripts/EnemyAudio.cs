using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour{
    private AudioSource audioSource;

    [SerializeField] private AudioClip fallingClip;

    private void Start() {
        audioSource = GetComponent<AudioSource>();}


    public void playFallingSound(){ 
        audioSource.PlayOneShot(fallingClip);}

}
