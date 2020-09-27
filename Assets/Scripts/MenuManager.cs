using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject ButtonAudio;
    AudioSource audio;
    void Start()
    {
        audio = ButtonAudio.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onPressPlay()
    {
        SceneManager.LoadScene("GameScene");
        audio.Play();
    }
    public void onPressExit()
    {
        Application.Quit();
        audio.Play();
    }
}
