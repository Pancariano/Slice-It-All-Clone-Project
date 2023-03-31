using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject winPanel, losePanel, inGamePanel;
    public TMP_Text levelText;

    [Header("Game State")]
    public bool menu;
    public bool win, lose, playing;

    public int levelInt = 1;

    private void Awake()
    {
        menu = true;
    }

    private void Update()
    {
        ChangeUI();
        UpdateLevel();
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (nextSceneIndex <= sceneIndex)
            SceneManager.LoadScene(nextSceneIndex);

        if (nextSceneIndex > sceneIndex)
            SceneManager.LoadScene(0);

        playing = true;
    }

    public void StartGame()
    {
        playing = true;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playing = true;
    }

    public void UpdateLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        levelText.text = "Level " + sceneIndex.ToString();
    }

    public void ChangeUI()
    {
        if (menu)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            inGamePanel.SetActive(false);
            mainPanel.SetActive(true);
        }

        if (win)
        {
            losePanel.SetActive(false);
            mainPanel.SetActive(false);
            inGamePanel.SetActive(false);
            winPanel.SetActive(true);
        }

        if (lose)
        {
            mainPanel.SetActive(false);
            winPanel.SetActive(false);
            inGamePanel.SetActive(false);
            losePanel.SetActive(true);
        }

        if (playing)
        {
            mainPanel.SetActive(false);
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            inGamePanel.SetActive(true);
            lose = false;
            menu = false;
            win = false;
        }
    }
}