using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionWindow : MonoBehaviour
{
    [Header("UI Элементы")]
    public GameObject selectionPanel;
    public Button startButton; 

    [Header("Цветовые элементы")]
    public Toggle redToggle;
    public GameObject redObject;

    public Toggle orangeToggle;
    public GameObject orangeObject;

    public Toggle yellowToggle;
    public GameObject yellowObject;

    public Toggle greenToggle;
    public GameObject greenObject;

    public Toggle lightBlueToggle;
    public GameObject lightBlueObject;

    public Toggle blueToggle;
    public GameObject blueObject;

    public Toggle purpleToggle;
    public GameObject purpleObject;

    public Toggle pinkToggle;
    public GameObject pinkObject;

    public Toggle magentaToggle;
    public GameObject magentaObject;

    public Toggle violetToggle;
    public GameObject violetObject;

    public Toggle limeToggle;
    public GameObject limeObject;

    public Toggle cyanToggle;
    public GameObject cyanObject;

    public Toggle grayToggle;
    public GameObject grayObject;

    public Toggle blackToggle;
    public GameObject blackObject;

    private void Start()
    {
        if (startButton == null || selectionPanel == null)
        {
            Debug.LogError("Кнопка или панель выбора не привязаны!");
            return;
        }

        startButton.onClick.AddListener(HandleStartButton);
        HideAllColorObjects();
    }

    private void HandleStartButton()
    {
        if (selectionPanel == null)
        {
            Debug.LogError("Панель выбора не установлена!");
            return;
        }

        SetActiveObject(redObject, redToggle?.isOn ?? false);
        SetActiveObject(orangeObject, orangeToggle?.isOn ?? false);
        SetActiveObject(yellowObject, yellowToggle?.isOn ?? false);
        SetActiveObject(greenObject, greenToggle?.isOn ?? false);
        SetActiveObject(lightBlueObject, lightBlueToggle?.isOn ?? false);
        SetActiveObject(blueObject, blueToggle?.isOn ?? false);
        SetActiveObject(purpleObject, purpleToggle?.isOn ?? false);
        SetActiveObject(pinkObject, pinkToggle?.isOn ?? false);
        SetActiveObject(magentaObject, magentaToggle?.isOn ?? false);
        SetActiveObject(violetObject, violetToggle?.isOn ?? false);
        SetActiveObject(limeObject, limeToggle?.isOn ?? false);
        SetActiveObject(cyanObject, cyanToggle?.isOn ?? false);
        SetActiveObject(grayObject, grayToggle?.isOn ?? false);
        SetActiveObject(blackObject, blackToggle?.isOn ?? false);

        selectionPanel.SetActive(false);
    }

    private void HideAllColorObjects()
    {
        SetActiveObject(redObject, false);
        SetActiveObject(orangeObject, false);
        SetActiveObject(yellowObject, false);
        SetActiveObject(greenObject, false);
        SetActiveObject(lightBlueObject, false);
        SetActiveObject(blueObject, false);
        SetActiveObject(purpleObject, false);
        SetActiveObject(pinkObject, false);
        SetActiveObject(magentaObject, false);
        SetActiveObject(violetObject, false);
        SetActiveObject(limeObject, false);
        SetActiveObject(cyanObject, false);
        SetActiveObject(grayObject, false);
        SetActiveObject(blackObject, false);
    }

    private void SetActiveObject(GameObject obj, bool isActive)
    {
        if (obj != null)
        {
            obj.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("Объект не привязан!");
        }
    }
}
