using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [Header("Scrolling")]
    [SerializeField] private float scrollSpeed = 80f;

    [Header("LoadScene")]
    [SerializeField] private int menuSceneNumber = 2;

    private RectTransform rectTransform;
    private Camera uiCamera;
    private bool canScroll = false;
    private float endWorldY;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // For Screen Space - Overlay canvas, uiCamera is null (that's fine)
        Canvas canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
    }

    private void Start()
    {
        StartCoroutine(InitAfterLayout());
    }

    private IEnumerator InitAfterLayout()
    {
        // Wait two frames to be sure ContentSizeFitter has finished
        yield return null;
        yield return null;

        float screenHeight = Screen.height;
        float contentHeight = rectTransform.rect.height;

        // Convert screen bottom and top to world space
        Vector3 screenBottom = new Vector3(Screen.width / 2f, 0, 0);
        Vector3 screenTop    = new Vector3(Screen.width / 2f, screenHeight, 0);

        Vector3 worldBottom = uiCamera != null
            ? uiCamera.ScreenToWorldPoint(screenBottom)
            : Camera.main.ScreenToWorldPoint(screenBottom);

        Vector3 worldTop = uiCamera != null
            ? uiCamera.ScreenToWorldPoint(screenTop)
            : Camera.main.ScreenToWorldPoint(screenTop);

        // For Screen Space - Overlay, just use pixel positions directly
        // Place content starting fully below the screen
        Vector3 startPos = rectTransform.position;
        startPos.y = worldBottom.y - contentHeight;
        rectTransform.position = startPos;

        // End when content is fully above the screen
        endWorldY = worldTop.y + contentHeight;

        canScroll = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
            return;
        }

        if (!canScroll) return;

        // Scroll upward
        Vector3 pos = rectTransform.position;
        pos.y += scrollSpeed * Time.deltaTime;
        rectTransform.position = pos;

        if (pos.y >= endWorldY)
            GoToMenu();
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneNumber);
    }
}