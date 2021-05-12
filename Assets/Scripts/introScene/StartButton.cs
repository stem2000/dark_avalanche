using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public static bool sceneEnd;
	public float fadeSpeed = 0.1f;
	public float volumeFading = 0.1f;
	[SerializeField] private AudioSource backgroundMusic;
	public int nextScene;
	private RawImage _image;
	public Canvas canvas;
	private bool sceneEnded;


    private AudioSource audioSource;
    [SerializeField] private AudioClip onClickClip;

    void Start(){
        audioSource = GetComponent<AudioSource>();
		_image = canvas.GetComponent<RawImage>();
		sceneEnded = false;}


	public void Update(){ 
		if(sceneEnded){ 
			canvas.gameObject.SetActive(true);
			endScene();}}


    public void StartGame(){ 
        audioSource.PlayOneShot(onClickClip);
        sceneEnded = true;}


    public void endScene (){
		_image.color  = new Color(_image.color.r,_image.color.g,_image.color.b,_image.color.a+fadeSpeed);
		backgroundMusic.volume -= volumeFading;
		if(_image.color.a >= 0.95f){
			SceneManager.LoadScene(nextScene);}}
}
