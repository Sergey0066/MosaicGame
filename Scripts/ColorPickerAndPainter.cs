using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    private static Color selectedColor = Color.white; // (белый)

    [Header("Цветовые кнопки")]
    public SpriteRenderer redButton; // Красный
    public SpriteRenderer orangeButton; // Оранжевый
    public SpriteRenderer yellowButton; // Жёлтый
    public SpriteRenderer greenButton; // Зелёный
    public SpriteRenderer cyanButton; // Бирюзовый
    public SpriteRenderer blueButton; // Синий
    public SpriteRenderer purpleButton; // Фиолетовый

    public SpriteRenderer pinkButton; // Розовый
    public SpriteRenderer magentaButton; // Малиновый
    public SpriteRenderer violetButton; // Сиреневый
    public SpriteRenderer limeButton; // Салатовый
    public SpriteRenderer grayButton; // Серый
    public SpriteRenderer blackButton; // Чёрный
    public SpriteRenderer lightBlueButton; // Голубой
    public SpriteRenderer whiteButton; // Белый

    void Start()
    {
        AssignColorToButton(redButton, Color.red);
        AssignColorToButton(orangeButton, new Color(1f, 0.5f, 0f)); // Оранжевый
        AssignColorToButton(yellowButton, Color.yellow);
        AssignColorToButton(greenButton, Color.green);
        AssignColorToButton(cyanButton, Color.cyan); // Бирюзовый
        AssignColorToButton(blueButton, Color.blue);
        AssignColorToButton(purpleButton, new Color(0.4745f, 0f, 0.7373f));

        AssignColorToButton(pinkButton, new Color(1f, 0.145f, 0.858f)); // Розовый
        AssignColorToButton(magentaButton, new Color(0.89f, 0.07f, 0.37f)); // Малиновый
        AssignColorToButton(violetButton, new Color(0.93f, 0.51f, 0.93f)); // Сиреневый
        AssignColorToButton(limeButton, new Color(0.5255f, 1f, 0.3176f)); // Салатовый
        AssignColorToButton(grayButton, Color.gray); // Серый
        AssignColorToButton(blackButton, Color.black); // Чёрный
        AssignColorToButton(lightBlueButton, new Color(0f, 0.7686f, 1f));
        AssignColorToButton(whiteButton, Color.white); // Белый
    }

    private void AssignColorToButton(SpriteRenderer button, Color color)
    {
        button.gameObject.AddComponent<BoxCollider2D>();
        button.gameObject.AddComponent<ColorButton>().Initialize(color);
    }

    public static void SelectColor(Color color)
    {
        selectedColor = color;
        Debug.Log($"Выбран цвет: {selectedColor}");
    }

    public static Color GetSelectedColor()
    {
        return selectedColor;
    }
}

public class ColorButton : MonoBehaviour
{
    private Color buttonColor;

    public void Initialize(Color color)
    {
        buttonColor = color;
    }

    private void OnMouseDown()
    {
        ColorPicker.SelectColor(buttonColor);
        Debug.Log($"Выбрана кнопка {gameObject.name} с цветом {buttonColor}");
    }
}
