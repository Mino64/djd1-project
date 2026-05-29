using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject pauseUI;

    [Header("Collectible Slots")]
    [SerializeField]
    private Image[] collectibleSlots = new Image[5];

    [SerializeField]
    private float opacity = 0.25f;

    [Header("Scene swap")]
    [SerializeField]
    private int mainMenuSceneNum = 2;

    private bool isPaused = false;

    private void Update()
    {
        if (isPaused)
        {
            HandlePausedInput();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }
    }

    private void OnEnable()
    {
        RefreshCollectibleSlots();
    }

    // Pause / Resume

    public void Pause()
    {
        RefreshCollectibleSlots();
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Input while paused

    private void HandlePausedInput()
    {
        // I or Escape → resume (unpause)
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            return;
        }

        // R → reset to last checkpoint, then reload current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
            return;
        }

        // M → go to main menu
        if (Input.GetKeyDown(KeyCode.M))
        {
            GoToMainMenu();
        }
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        CollectibleManager.Instance?.ClearCheckpoint();
        SceneManager.LoadScene(mainMenuSceneNum);
    }

    public void RefreshCollectibleSlots()
    {
        if (CollectibleManager.Instance == null) return;

        bool[] collected = CollectibleManager.Instance.GetAllCollected();

        for (int i = 0; i < collectibleSlots.Length; i++)
        {
            if (collectibleSlots[i] == null) continue;

            bool isCollected = i < collected.Length && collected[i];
            Sprite sprite = CollectibleManager.Instance.GetSprite(i);

            if (isCollected && sprite != null)
            {
                collectibleSlots[i].sprite = sprite;
                collectibleSlots[i].color = Color.white;
            }
            else
            {
                collectibleSlots[i].color = new Color(1f, 1f, 1f, opacity);
            }
        }
    }
}