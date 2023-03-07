using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseCanvas;

    public event EventHandler onGameOver;

    private bool isPaused = false;
    
    public static GameManager Instance { get;private set; }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Instance = this;

        Time.timeScale = 1f;
    }

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        GameInput.Instance.onPause += GameInput_onPause;
    }

    private void GameInput_onPause(object sender, EventArgs e)
    {
        isPaused = !isPaused;

        if (isPaused) { pauseCanvas.SetActive(true); Time.timeScale = 0f; }
        else { pauseCanvas.SetActive(false); Time.timeScale = 1f; }
    }

    private void Update()
    {
        if (!audioSource.isPlaying && !isPaused)
        {
            onGameOver?.Invoke(this,EventArgs.Empty);
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;

            GameObject[] redCubesRemaining = GameObject.FindGameObjectsWithTag("RC");
            GameObject[] blueCubesRemaining = GameObject.FindGameObjectsWithTag("BC");

            foreach (GameObject cube in redCubesRemaining) { Destroy(cube); }
            foreach (GameObject cube in blueCubesRemaining) { Destroy(cube); }
        }
    }
}
