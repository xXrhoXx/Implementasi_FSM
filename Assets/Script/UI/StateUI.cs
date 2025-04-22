using TMPro;
using UnityEngine;

public class StateUI : MonoBehaviour
{
    TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    internal void SetText(string text)
    {
        this.text.SetText(text);
    }
}
