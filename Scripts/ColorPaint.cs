using UnityEngine;

public class Paintable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError($"�� ������� {gameObject.name} ����������� SpriteRenderer!");
        }

        gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            Color selectedColor = ColorPicker.GetSelectedColor();
            spriteRenderer.color = selectedColor;
            Debug.Log($"������ {gameObject.name} ������� � {selectedColor}");
        }
        else
        {
            Debug.LogError($"SpriteRenderer �� ������ �� ������� {gameObject.name}");
        }
    }
}
