using UnityEngine;

public class Paintable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError($"На объекте {gameObject.name} отсутствует SpriteRenderer!");
        }

        gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            Color selectedColor = ColorPicker.GetSelectedColor();
            spriteRenderer.color = selectedColor;
            Debug.Log($"Объект {gameObject.name} окрашен в {selectedColor}");
        }
        else
        {
            Debug.LogError($"SpriteRenderer не найден на объекте {gameObject.name}");
        }
    }
}
