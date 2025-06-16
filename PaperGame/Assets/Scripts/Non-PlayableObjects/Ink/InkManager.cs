using UnityEngine;

public class InkManager : MonoBehaviour
{
    private GameObject inkCartridgePrefab;

    private void Awake()
    {
        inkCartridgePrefab = Resources.Load<GameObject>("InkCartridge");
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnInkCartridge), 1.0f, 2.0f);
    }

    private void SpawnInkCartridge()
    {
        float height = Random.Range(-2.0f, 2.5f);
        GameObject.Instantiate(inkCartridgePrefab, new Vector2(-3.0f, height), Quaternion.identity);
    }
}
