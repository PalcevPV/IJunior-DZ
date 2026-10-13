using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private int _actionButton = 0;
    public event Action Clicked;

    private void Update()
    {
        CheckMouseClick();
    }

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(_actionButton))
        {
            Clicked?.Invoke();
        }
    }
}
