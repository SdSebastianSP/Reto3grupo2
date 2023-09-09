using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int[] scoreList = new int[5];
    [SerializeField] private TextMeshProUGUI scoreText;
    private static int currentIndex;

    private void Start()
    {
        scoreText.text = "X 0";
    }

    public void SumScore()
    {
        scoreList[currentIndex] += 1;
        scoreText.text = "X " + scoreList[currentIndex];
    }

    public void resetScore()
    {
        for (int u = 0; u < scoreList.Length; u++)
            scoreList[u] = 0;

        scoreText.text = "X 0";
    }

    public void getFinalScore()
    {
        int total = 0;
        for (int u = 0; u < scoreList.Length; u++)
            total += scoreList[u];
    }

    public void Update()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
