using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManger : MonoBehaviour
{
    [SerializeField] Image deneme;
    [SerializeField] float count;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject imagePanel;

    bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        deneme.fillAmount = 0;
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
        if (!isStart) FillObject();
    }

    void FillObject()
    {
        if (count <= 1f)
        {
            count += Time.deltaTime * 0.25f;
            deneme.fillAmount = count / 1;
        }
        else if (count > 1f)
        {
            isStart = true;
            imagePanel.SetActive(false);
            spawner.SetActive(true);
        }
    }

}
