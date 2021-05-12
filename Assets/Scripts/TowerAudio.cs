using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAudio : MonoBehaviour{
    private AudioSource audioSource;

    [SerializeField] private AudioClip attackClip;

    private void Start() {
        audioSource = GetComponent<AudioSource>();}


    public void playAttackSound(){ 
        audioSource.PlayOneShot(attackClip);}

}
