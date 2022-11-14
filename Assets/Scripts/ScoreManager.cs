using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public static int currentNum, maxNum;

    [SerializeField] int minScore, MaxScore;

    // Start is called before the first frame update
    void Start()
    {
        currentNum = 0;
        maxNum = Random.Range(minScore, MaxScore);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentNum.ToString() + " / " + maxNum.ToString();
        NextLevel(currentNum);
    }

    void NextLevel(int num)
    {
        if (num == maxNum)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
