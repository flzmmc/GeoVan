using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDetected : MonoBehaviour
{
    protected Touch touch;

    protected Ray ray;
    protected RaycastHit2D hit;

    [SerializeField] int maxNum;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TouchDetect()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
            hit = Physics2D.GetRayIntersection(ray);

        }
    }

    public void NextLevel(int num)
    {
        if(num == maxNum)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
