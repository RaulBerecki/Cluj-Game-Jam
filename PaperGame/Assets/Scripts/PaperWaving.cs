using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PaperWaving : MonoBehaviour
{
    private List<Transform> paperSegments = new List<Transform>(); // Segments from top to bottom or left to right
    private float waveSpeed = 3f;
    private float waveAmplitude = 5f;
    private float segmentOffset = 0.025f;

    private float verticalAmplitude = 0.125f; // How much it moves up and down
    private List<Vector3> initialPositions = new List<Vector3>();

    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            if(child.gameObject.name.Contains("PaperBit"))
            {
                paperSegments.Add(child);
                initialPositions.Add(child.localPosition);
            }
        }
    }
    void Update()
    {
        for (int i = 0; i < paperSegments.Count; i++)
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
