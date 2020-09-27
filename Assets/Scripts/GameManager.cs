using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Egg;
    [SerializeField] GameObject Character;
    [SerializeField] GameObject FinishLine;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject FinishCollider;
    
    [Space]
    [SerializeField] GameObject[] Levels;
    [Space]
    [SerializeField] GameObject WinAudioGameObject;
    [SerializeField] GameObject LoseAudioGameObject;
    [SerializeField] GameObject HatchingAudioGameObject;
    AudioSource WinAudio;
     AudioSource LoseAudio;
     


    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("WhichLevel") == null)
        {
            PlayerPrefs.SetInt("WhichLevel", 0);
        }
        WinAudio = WinAudioGameObject.GetComponent<AudioSource>();
        LoseAudio = LoseAudioGameObject.GetComponent<AudioSource>();
        
        LevelControl();
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
        FinishLine.SetActive(false);
        GameHolder.isGameover = false;
        GameHolder.isHatching = false;
        GameHolder.isCameraWatchEgg = true;
        GameHolder.isDie = false;
        GameHolder.isLevelPassed = false;
}
    void Update()
    {
        HatchingControl();
        GameOverControl();
    }
    private void LevelControl()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("WhichLevel"))
            {
                Levels[i].gameObject.SetActive(true);
            }
            else
            {
                Levels[i].gameObject.SetActive(false);
            }
        }
    }

    private void GameOverControl()
    {
        if (GameHolder.isDie)
        {
            LoseAudioGameObject.SetActive(true);
            LosePanel.SetActive(true);
            WinPanel.SetActive(false);
            FinishCollider.SetActive(false);

        }
        if (GameHolder.isLevelPassed)
        {
            WinAudioGameObject.SetActive(true);
            LosePanel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }

    private void HatchingControl()
    {
        if (GameHolder.isHatching)
        {
            HatchingAudioGameObject.SetActive(true);
            FinishLine.SetActive(true);
            Vector3 eggPos = Egg.transform.position;
            Egg.gameObject.SetActive(false);
            Character.transform.position = eggPos+new Vector3(0,1,0);
            Character.SetActive(true);
            GameHolder.isCameraWatchEgg = false;
            GameHolder.isHatching = false;
        }
    }
    public void onPressNextLevel()
    {
        
        PlayerPrefs.SetInt("WhichLevel", PlayerPrefs.GetInt("WhichLevel") + 1);
        SceneManager.LoadScene("GameScene");
    }
    public void onPressBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void onPressReplay()
    {
        SceneManager.LoadScene("GameScene");
    }
}
