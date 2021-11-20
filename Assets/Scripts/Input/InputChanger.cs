using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputChanger : MonoBehaviour
{

    public InputMovement playerMovement;
    public Text inputTypeText;

    private string template = "Control: {0}\n[Press Left Shift To Switch]";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (playerMovement.inputType)
            {
                case InputType.Mouse:
                    playerMovement.inputType = InputType.Keyboard;
                    inputTypeText.text = string.Format(template, "Keyboard");
                    break;
                case InputType.Keyboard:
                    playerMovement.inputType = InputType.Mouse;
                    inputTypeText.text = string.Format(template, "Mouse");
                    break;
            }
        }
    }
}
