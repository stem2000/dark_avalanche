using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float period;
    private int state;
    public bool isStarted;

    public static int stoped = 0;
    public static int working = 1;
    public static int ended = 2;

    public void Start(){
        period = -1;
        state = stoped;}

    public void startTimer(float period) {
        if(state == working || state == ended) return;
        this.period = period;
        state = working;}


    public void FixedUpdate(){
        if(period - Time.fixedDeltaTime > 0 && state == working){
            period -= Time.fixedDeltaTime;}
        else if(state == working){
            state = ended;}}

    public int timerState(){ 
        return state;}

    public void reactivateTimer(){ 
        state = stoped;}

}
