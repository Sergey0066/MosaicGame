using UnityEngine;

public class QuitGameOnSpriteClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("�������� ����...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
