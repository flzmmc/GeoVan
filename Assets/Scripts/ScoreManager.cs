using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public static int currentNum, maxNum;

    // Start is called before the first frame update
    void Start()
    {
        currentNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentNum.ToString() + " / " + maxNum.ToString();
    }
}
