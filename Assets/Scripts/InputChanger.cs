using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputChanger : MonoBehaviour
{

    public InputMovement playerMovement;
    public Text inputTypeText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (playerMovement.inputType)
            {
                case InputType.Mouse:
                    playerMovement.inputType = InputType.Keyboard;
                    inputTypeText.text = "Control: Keyboard";
                    break;
                case InputType.Keyboard:
                    playerMovement.inputType = InputType.Mouse;
                    inputTypeText.text = "Control: Mouse";
                    break;
            }
        }
    }
}
