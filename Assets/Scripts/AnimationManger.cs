using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManger : MonoBehaviour
{
    [SerializeField] List<Image> deneme;
    [SerializeField] float count;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject imagePanel;

    [SerializeField] GameObject circle;

    bool isStart;
    int index = 0;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        //deneme.fillAmount = 0;
        //while (deneme.fillAmount >= 1)
        //{
        //    deneme.fillAmount += count;
        //    Debug.Log(deneme.fillAmount);
        //    deneme.fillClockwise = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isStart) FillObject();
        count += Time.deltaTime * speed;
        circle.transform.localScale = new Vector3(1f + Mathf.Abs(Mathf.Sin(count)), 1f + Mathf.Abs(Mathf.Sin(count)), 1f);
    }

    void FillObject()
    {
        
        if (count <= 1f)
        {
            count += Time.deltaTime * 0.25f;
            deneme[index].fillAmount = count / 1;
        }
        else if (count >= 1f)
        {
            if (index < deneme.Count) index++;
            count = 0f;
            
            //isStart = true;
            //imagePanel.SetActive(false);
            //spawner.SetActive(true);
        }
    }

}
