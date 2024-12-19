using UnityEngine;

namespace MyGame.Utility
{
    public class QuitGameOnSpriteClick : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log("�������� ����...");

#if UNITY_EDITOR
            // ��������� ������ ���� � ��������� Unity
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
