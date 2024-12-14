using UnityEngine;

namespace MyGame.Utility
{
    public class QuitGameOnSpriteClick : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log("Закрытие игры...");

#if UNITY_EDITOR
            // Остановка режима игры в редакторе Unity
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
