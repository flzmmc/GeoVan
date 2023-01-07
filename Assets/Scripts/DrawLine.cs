using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    GameObject currentLine;

    LineRenderer lineRenderer;
    public List<Vector2> fingerPositions;

    Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && LevelManager.isPlayable)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && ObjectMatching.firstTouch)
            {
                CreateLine();
            }
            else if (touch.phase == TouchPhase.Moved && ObjectMatching.firstTouch)
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(touch.position);
                if(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
                {
                    UpdateLine(tempFingerPos);
                }
            }
            else if (touch.phase == TouchPhase.Ended && !ObjectMatching.correctAnswer)
            {
                DeleteLine();
            }
        }
    }
    //Parmak dokunu�u oldu�u an �nceki pozisyonl�ar� sil ve parma��n dokundu�u yere Line olu�tur
    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(touch.position));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(touch.position));

        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
    }
    //Parma��n hareketini al ve Line'a yeni pozisyon ekle
    //Pozisyon parma��n pozisyonuna e�it olsun
    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
    }
    //Olu�an Line'� sil
    void DeleteLine()
    {
        Destroy(currentLine);
    }
}
