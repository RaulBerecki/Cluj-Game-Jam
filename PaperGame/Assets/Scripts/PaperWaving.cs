using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PaperWaving : MonoBehaviour
{
    public Transform[] paperSegments; // Segments from top to bottom or left to right
    public float waveSpeed = 2f;
    public float waveAmplitude = 5f;
    public float segmentOffset = 0.15f;

    public float verticalAmplitude = 0.05f; // How much it moves up and down
    private Vector3[] initialPositions;

    void Start()
    {
        // Store initial positions to offset correctly
        initialPositions = new Vector3[paperSegments.Length];
        for (int i = 0; i < paperSegments.Length; i++)
        {
            initialPositions[i] = paperSegments[i].localPosition;
        }
    }
    void Update()
    {
        for (int i = 0; i < paperSegments.Length; i++)
        {
            float offset = i * segmentOffset;
            float wave = Mathf.Sin(Time.time * waveSpeed + offset);

            //Rotation Movement
            float angle = Mathf.Sin(Time.time * waveSpeed + offset) * waveAmplitude;
            paperSegments[i].localRotation = Quaternion.Euler(0, 0, angle);

            // Vertical Movement
            Vector3 pos = initialPositions[i];
            pos.y += wave * verticalAmplitude;
            paperSegments[i].localPosition = pos;
        }
    }
}
