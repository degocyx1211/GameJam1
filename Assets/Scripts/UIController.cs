using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    //public TMPro.TextMeshProUGUI scorePlayerText;
    //public TMPro.TextMeshProUGUI scoreEnemyText;

    public int scorePlayerGame;
    public int scoreEnemyGame;
    public int scoreToWin = 10;

    public GameObject panelStart;
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject panelPause;

    public Button starButton;
    public Button restarButtonWin;
    public Button restarButtonLose;
    public Button resumeButtonPause;
    public Button restartButtonPause;

    //public AudioSource starMusic;
    //public AudioSource musicGame;
    //public AudioSource musicWin;
    //public AudioSource musicLose;

    public bool flagToMusic;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StarGame();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }

        ScoreAcutiliced();
        if (scorePlayerGame >= scoreToWin && flagToMusic == true)
        {
            WinGame();
        }
        if (scoreEnemyGame >= scoreToWin && flagToMusic == true)
        {
            LoseGame();
        }
    }

    void StarGame()
    {
        // Listener que trae a IniciarJuego
        starButton.onClick.AddListener(StartButtonGame);
        restarButtonWin.onClick.AddListener(RestartGame);
        restarButtonLose.onClick.AddListener(RestartGame);
        resumeButtonPause.onClick.AddListener(UnPause);
        restartButtonPause.onClick.AddListener(RestartGame);
        panelStart.SetActive(true);
        //starMusic.Play();
        flagToMusic = true;
        Time.timeScale = 0f;
    }
    void StartButtonGame()
    {
        panelStart.SetActive(false);
        Time.timeScale = 1f;
        //starMusic.Stop();
        //musicGame.Play();

    }

    void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    void UnPause()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    void WinGame()
    {
        panelWin.SetActive(true);
        //musicGame.Stop();
        //musicWin.Play();
       //flagToMusic = false;
        Time.timeScale = 0f;

    }

    void LoseGame()
    {
        panelLose.SetActive(true);
        //musicGame.Stop();
        //musicLose.Play();
        //flagToMusic = false;
        Time.timeScale = 0f;
    }

    void ScoreAcutiliced()
    {
        //scorePlayerText.text = "" + scorePlayerGame;
        //scoreEnemyText.text = "" + scoreEnemyGame;
    }

    void RestartGame()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual);
    }

}
