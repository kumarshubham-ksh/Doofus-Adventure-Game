using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentScore"))
        {
            PlayerPrefs.SetInt("CurrentScore", 0);
        }
        scoreText.text = "0";
    }

    public void Update()
    {
        scoreText.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        if(PlayerPrefs.GetInt("CurrentScore", 0) >= 50 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(3);
        }
    }
}
