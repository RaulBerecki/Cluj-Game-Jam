using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, pausePanel, gameOverPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuPanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOn()
    {
        menuPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    public void GamePause()
    {
        menuPanel.SetActive(false);
        pausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
    public void GameOver()
    {
        menuPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
