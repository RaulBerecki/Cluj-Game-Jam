using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;
    int swipes=0;
    //DoubleClickVars
    public float doubleClickThreshold = 0.3f; // Time window for double click
    private float lastClickTime = 0f;

    [SerializeField] private RoomManager roomManager;
    [SerializeField] private UserInterfaceManager userInterfaceManager;
    [SerializeField] private InkManager inkManager;
    void Update()
    {
        CheckForDoubleClick();
        if(Input.GetMouseButtonDown(0))
        {
            OnClickStart();
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (swipes == 0)
            {
                roomManager.isPlaying = true;
                inkManager.isPlaying = true;
                userInterfaceManager.GameOn();
                swipes++;
            }
            OnClickEnd();
        }
    }

    private void CheckForDoubleClick()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            if (Time.time - lastClickTime < doubleClickThreshold)
            {
                // Double click detected
                if (roomManager.isPlaying)
                {
                    roomManager.isPlaying = false;
                    inkManager.isPlaying = false;
                    userInterfaceManager.GamePause();
                }
                else
                {
                    roomManager.isPlaying = true;
                    inkManager.isPlaying = true;
                    userInterfaceManager.GameOn();
                }
            }
            lastClickTime = Time.time;
        }
    }
    private void OnClickStart()
    {
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnClickEnd()
    {
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = endPoint - startPoint;
        RaycastHit2D hit = Physics2D.Raycast(startPoint, direction);

        if(hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            string layerName = LayerMask.LayerToName(hitObject.layer);

            if ("Paper" == layerName)
            {
                sendBall();
                //Debug.DrawRay(startPoint, direction.normalized * 5f, Color.red, 1f);
                //hitObject.transform.parent.GetComponent<PaperWaving>().pushPaper(hitObject.transform);
            }
        }
    }

    private void sendBall()
    {
        GameObject ball = GameObject.Instantiate(Resources.Load<GameObject>("PaperBit"), startPoint, Quaternion.identity);
        ball.AddComponent<WindController>();
        ball.AddComponent<Rigidbody2D>();
        ball.layer = LayerMask.NameToLayer("Default");

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = (endPoint - startPoint) * 5.0f;        
    }
}
