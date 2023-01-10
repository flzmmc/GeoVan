using UnityEngine;

public class DragObject : MonoBehaviour
{
    public static bool isPlacement = false;

    Touch touch;

    Transform dragObject;

    Vector3 firstPos;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
    }
    //Ekrana dokunulursa ve dokunulan objede PlacementManager script'i yoksa
    //Objenin tag'ý "Untagged" ise objenin ilk pozisyonunu al
    //Eðer eþleþme olursa Collider2D özelliklerini kapat ve pozisyonunu deðiþtirme
    //Eðer eþleþtirme olmazsa objenin pozisyonunu ilk pozisyonuna eþitle.
    void TouchDetect()
    {
        if (Input.touchCount > 0 && LevelManager.isPlayable)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if(touch.phase == TouchPhase.Began && hit.collider != null && hit.collider.gameObject.GetComponent<PlacementManager>() != null)
            {
                ScoreManager.isWrong = true;
                return;
            }

            if (touch.phase == TouchPhase.Began && hit.collider != null)
            {
                if (!hit.collider.gameObject.CompareTag("Untagged"))
                {
                    dragObject = hit.collider.transform.parent.gameObject.transform;
                }
                else dragObject = hit.collider.gameObject.transform;
                firstPos = dragObject.position;

            }
            else if (touch.phase == TouchPhase.Began && hit.collider == null) ScoreManager.isWrong = true;

            else if (touch.phase == TouchPhase.Moved && dragObject != null)
            {
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(touch.position);
                objectPos.z = 0f;
                dragObject.position = objectPos;
            }
            else if (touch.phase == TouchPhase.Ended && hit.collider == null) ScoreManager.isWrong = true;

            else if (touch.phase == TouchPhase.Ended && hit.collider != null && !isPlacement)
            {
                dragObject.position = firstPos;
                dragObject = null;
            }
            
            else if (touch.phase == TouchPhase.Ended && hit.collider != null && isPlacement)
            {
                if (hit.collider.transform.parent.gameObject != null && hit.collider.transform.parent.gameObject.GetComponent<Collider2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                    hit.collider.transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
                }
                else
                {
                    hit.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                    hit.collider.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
                }

                isPlacement = false;
                dragObject = null;
            }

            

        }
    }
}
