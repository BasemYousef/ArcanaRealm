using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject controlPanel;
    void Start()
    {
        controlPanel.SetActive(false);
    }
    public void ActivateControlPanel()
    {
        controlPanel.SetActive(true);
        
    }
    public void DeactivatingControlPanel()
    {
        controlPanel?.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
