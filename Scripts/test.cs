using UnityEngine;

public class TestClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} был нажат.");
    }
}
