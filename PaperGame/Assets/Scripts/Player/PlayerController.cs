using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClickStart();
        }
        if(Input.GetMouseButtonUp(0))
        {
            OnClickEnd();
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
