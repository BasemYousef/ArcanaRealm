using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameEnds = false;
    [SerializeField]public GameObject gameOverCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject victoryPanel;
    private bool isGamePaused = false;
   
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        gameOverCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        victoryPanel.SetActive(false);
    }
   
    private void Update()
    {
      if (Input.GetKeyUp(KeyCode.Escape))   
        {
            if (isGamePaused)
            {
                Resume();
            }
            else Pause();
        }
    }
 
   public void GameOverCanvas()
    {
         gameEnds = true;
      if(gameEnds == true)
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void backmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
   public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void VictoryPanel()
    {
        victoryPanel.SetActive(true);
    }
}
