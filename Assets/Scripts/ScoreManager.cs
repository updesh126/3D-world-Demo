using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;
    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private GameObject _gameUi;

    [SerializeField]
    private GameObject _NextLevel;

    [SerializeField]
    private TextMeshProUGUI _textScore;

    [SerializeField]
    private TextMeshProUGUI _FinalScore;



    static int _score;

    private bool isGameOver = false;

    private void Start()
    {
        // Ensure the game over UI is initially disabled
        _gameOver.SetActive(false);
        _gameUi.SetActive(true);
        _score = 0000;
    }

    private void ADD_Score(int score)
    {
        _score += score;
        _textMeshPro.text = _score.ToString();
    }
    private void REMOVE_Score(int score)
    {
        _score -= score;
        _textMeshPro.text = _score.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            Debug.Log("Collide Sphere");
            other.gameObject.SetActive(false);
            ADD_Score(10);
        }
        if (other.gameObject.tag == "Cube")
        {
            Debug.Log("Collide Cube");
            other.gameObject.SetActive(false);
            ADD_Score(40);
        }
        if (other.gameObject.tag == "prime")
        {
            Debug.Log("Collide Cube");
            other.gameObject.SetActive(false);
            ADD_Score(80);
        }
        if (other.gameObject.tag == "Fire")
        {
            Debug.Log("Collide Fire");
            GameOver();
        }
        if (other.gameObject.tag == "congratulations")
        {
            Debug.Log("Collide congratulations");
            Level_Done();
        }
    }

    private void GameOver()
    {
        // Set the game over flag to prevent multiple triggers
        isGameOver = true;

        // Display the game over UI panel or screen
        _gameOver.SetActive(true);

        _textScore.text= _score.ToString() + "  Score";

        _gameUi.SetActive(false);

        // Optionally, you can also pause the game at this point
        Time.timeScale = 0f;
    }

    public void RestartGame(string name)
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(name);

        // Ensure the time scale is set back to 1 to resume the game
        Time.timeScale = 1f;
    }

    private void Level_Done()
    {
        // Set the game over flag to prevent multiple triggers
        

        // Display the game over UI panel or screen
        _NextLevel.SetActive(true);

        _FinalScore.text = _score.ToString() + "  Score";

        _gameUi.SetActive(false);

        // Optionally, you can also pause the game at this point
        Time.timeScale = 0f;
    }
    public  void NextLevel(string name)
    {
        SceneManager.LoadScene(name);

        // Ensure the time scale is set back to 1 to resume the game
        Time.timeScale = 1f;
    }
}
