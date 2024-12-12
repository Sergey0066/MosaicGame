using UnityEngine;
using System.IO;

public class AreaScreenshotWithSprite : MonoBehaviour
{
    public Camera screenshotCamera; // Камера объекта
    public Camera mainCamera; // Основная камера
    public RenderTexture renderTexture; 
    public string defaultFileName = "screenshot.png"; // Имя файла

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("Основная камера не найдена! Убедитесь, что на камеру установлен тег 'MainCamera'.");
            }
        }

        if (screenshotCamera != null)
        {
            screenshotCamera.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private System.Collections.IEnumerator CaptureScreenshot()
    {
        if (mainCamera == null || screenshotCamera == null || renderTexture == null)
        {
            Debug.LogError("Одна или несколько необходимых камер не указаны. Проверьте настройки.");
            yield break;
        }

        mainCamera.enabled = false;
        screenshotCamera.enabled = true;

        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;
        screenshotCamera.targetTexture = renderTexture;
        screenshotCamera.Render();

        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        RenderTexture.active = null;
        screenshotCamera.targetTexture = null;

        SaveScreenshot(texture);

        Destroy(texture);

        screenshotCamera.enabled = false;
        mainCamera.enabled = true;
    }

    private void SaveScreenshot(Texture2D texture)
    {
        string path;

#if UNITY_EDITOR
        // Используем диалоговое окно для сохранения в редакторе
        path = UnityEditor.EditorUtility.SaveFilePanel(
            "Сохранить скриншот",
            Application.dataPath,
            defaultFileName,
            "png");

        if (string.IsNullOrEmpty(path))
        {
            Debug.LogWarning("Сохранение скриншота отменено пользователем.");
            return;
        }
#else
        string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "UnityScreenshots");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        path = Path.Combine(folderPath, defaultFileName);
        Debug.Log($"Скриншот будет сохранен по пути: {path}");
#endif

        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(path, bytes);
        Debug.Log($"Скриншот сохранен: {path}");
    }
}
