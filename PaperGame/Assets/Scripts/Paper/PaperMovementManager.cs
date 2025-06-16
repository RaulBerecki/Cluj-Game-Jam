using UnityEngine;

public class PaperMovementManager : MonoBehaviour
{
    private Vector2 targetLocation = new Vector2(0f, 0f);
    private float speed = 0.02f;

    void Update()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, targetLocation, speed);
    }

    public void setTargetLocationY(float y)
    {
        targetLocation.y = y;
        Debug.Log($"[PaperMovementManager] Target Location set to: {targetLocation}");
    }
}
