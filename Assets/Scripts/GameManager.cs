using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public static GameManager Instance;
    public int coinsObtained = 0;
    public GameObject pauseMenuUI;
    private bool IsPause = false;
    public bool BossDefeated = false;
    public GameObject boss;

    private void Start()
    {
     
        pauseMenuUI.SetActive(false);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        

    }
    public void ObtainCoin()
    {
        coinsObtained++;
        Debug.Log("Coins = " + coinsObtained);
        coinsText.text = "Coins = " + coinsObtained;
    }
     

        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPause == true)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            IsPause = false;
        }
        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPause = true;
        }
        public void UnPauseButton()
        {
            Resume();
        }
        public void BackToMenuButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("StartScene");
        }
        public void QuitToDesktop()
        {
            Application.Quit();
        }
    }

