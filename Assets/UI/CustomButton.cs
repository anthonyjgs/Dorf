using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class CustomButton : MonoBehaviour
{
    public Text text;
    public Color highlightColor;
    private Color baseColor;

    [SerializeField]
    private UnityEvent OnClick;

    // Start is called before the first frame update
    void Start()
    {
        baseColor = text.color;
    }

    // When this object is clicked
    public void OnPointerDown()
    {
        OnClick.Invoke();
    }

    public void OnPointerEnter()
    {
        text.color = highlightColor;
    }

    public void OnPointerExit()
    {
        text.color = baseColor;
    }
}
