using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    private static Color selectedColor = Color.white; // (�����)

    [Header("�������� ������")]
    public SpriteRenderer redButton; // �������
    public SpriteRenderer orangeButton; // ���������
    public SpriteRenderer yellowButton; // Ƹ����
    public SpriteRenderer greenButton; // ������
    public SpriteRenderer cyanButton; // ���������
    public SpriteRenderer blueButton; // �����
    public SpriteRenderer purpleButton; // ����������

    public SpriteRenderer pinkButton; // �������
    public SpriteRenderer magentaButton; // ���������
    public SpriteRenderer violetButton; // ���������
    public SpriteRenderer limeButton; // ���������
    public SpriteRenderer grayButton; // �����
    public SpriteRenderer blackButton; // ׸����
    public SpriteRenderer lightBlueButton; // �������
    public SpriteRenderer whiteButton; // �����

    void Start()
    {
        AssignColorToButton(redButton, Color.red);
        AssignColorToButton(orangeButton, new Color(1f, 0.5f, 0f)); // ���������
        AssignColorToButton(yellowButton, Color.yellow);
        AssignColorToButton(greenButton, Color.green);
        AssignColorToButton(cyanButton, Color.cyan); // ���������
        AssignColorToButton(blueButton, Color.blue);
        AssignColorToButton(purpleButton, new Color(0.4745f, 0f, 0.7373f));

        AssignColorToButton(pinkButton, new Color(1f, 0.145f, 0.858f)); // �������
        AssignColorToButton(magentaButton, new Color(0.89f, 0.07f, 0.37f)); // ���������
        AssignColorToButton(violetButton, new Color(0.93f, 0.51f, 0.93f)); // ���������
        AssignColorToButton(limeButton, new Color(0.5255f, 1f, 0.3176f)); // ���������
        AssignColorToButton(grayButton, Color.gray); // �����
        AssignColorToButton(blackButton, Color.black); // ׸����
        AssignColorToButton(lightBlueButton, new Color(0f, 0.7686f, 1f));
        AssignColorToButton(whiteButton, Color.white); // �����
    }

    private void AssignColorToButton(SpriteRenderer button, Color color)
    {
        button.gameObject.AddComponent<BoxCollider2D>();
        button.gameObject.AddComponent<ColorButton>().Initialize(color);
    }

    public static void SelectColor(Color color)
    {
        selectedColor = color;
        Debug.Log($"������ ����: {selectedColor}");
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
        Debug.Log($"������� ������ {gameObject.name} � ������ {buttonColor}");
    }
}
