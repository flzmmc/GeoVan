using UnityEngine;
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
        //Eðer sabit skor koþulu yanlýþsa rastgele skor belirler, doðruysa sabit skoru al
        if (!fixedScoreCheck) maxNum = Random.Range(minScore, maxScore);
        else maxNum = fixedScore;
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = currentNum.ToString() + " / " + maxNum.ToString();
    }

    
}
