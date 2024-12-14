using System.Collections;
using System.IO;
using UnityEngine;

namespace YourNamespace.Screenshot
{
    public class AreaScreenshotHandler : MonoBehaviour
    {
        [Header("��������� �����")]
        [SerializeField] private Camera screenshotCamera; // ������ �������
        [SerializeField] private Camera mainCamera; // �������� ������

        [Header("�������� �������")]
        [SerializeField] private RenderTexture renderTexture;

        [Header("��� �����")]
        [SerializeField] private string defaultFileName = "screenshot.png"; // ��� ����� �� ���������

        private void Start()
        {
            ValidateCameraSettings();
        }

        private void OnMouseDown()
        {
            StartCoroutine(CaptureScreenshot());
        }

        private void ValidateCameraSettings()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
                if (mainCamera == null)
                {
                    Debug.LogError("�������� ������ �� �������! ���������, ��� �� ������ ���������� ��� 'MainCamera'.");
                }
            }

            if (screenshotCamera != null)
            {
                screenshotCamera.enabled = false;
            }
        }

        private IEnumerator CaptureScreenshot()
        {
            if (!ValidateScreenshotSettings())
            {
                yield break;
            }

            SwitchToScreenshotCamera();

            yield return new WaitForEndOfFrame();

            Texture2D texture = RenderToTexture();
            SaveScreenshot(texture);

            CleanupAfterCapture(texture);
            SwitchToMainCamera();
        }

        private bool ValidateScreenshotSettings()
        {
            if (mainCamera == null || screenshotCamera == null || renderTexture == null)
            {
                Debug.LogError("���� ��� ��������� ����������� ����� �� �������. ��������� ���������.");
                return false;
            }
            return true;
        }

        private void SwitchToScreenshotCamera()
        {
            mainCamera.enabled = false;
            screenshotCamera.enabled = true;
        }

        private void SwitchToMainCamera()
        {
            screenshotCamera.enabled = false;
            mainCamera.enabled = true;
        }

        private Texture2D RenderToTexture()
        {
            Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

            RenderTexture.active = renderTexture;
            screenshotCamera.targetTexture = renderTexture;
            screenshotCamera.Render();

            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();

            RenderTexture.active = null;
            screenshotCamera.targetTexture = null;

            return texture;
        }

        private void SaveScreenshot(Texture2D texture)
        {
            string path;

#if UNITY_EDITOR
            path = UnityEditor.EditorUtility.SaveFilePanel(
                "��������� ��������",
                Application.dataPath,
                defaultFileName,
                "png");

            if (string.IsNullOrEmpty(path))
            {
                Debug.LogWarning("���������� ��������� �������� �������������.");
                return;
            }
#else
            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "UnityScreenshots");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            path = Path.Combine(folderPath, defaultFileName);
            Debug.Log($"�������� ����� �������� �� ����: {path}");
#endif

            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
            Debug.Log($"�������� ��������: {path}");
        }

        private void CleanupAfterCapture(Texture2D texture)
        {
            Destroy(texture);
        }
    }
}
