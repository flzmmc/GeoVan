using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public static int currentNum, maxNum;

    [SerializeField] int minScore, maxScore;
    [SerializeField] int fixedScore;

    [SerializeField] bool fixedScoreCheck;

    // Start is called before the first frame update
    void Start()
    {
        currentNum = 0;
        if (!fixedScoreCheck) maxNum = Random.Range(minScore, maxScore);
        else maxNum = fixedScore;
        
        
        
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
