using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfoDisplay : MonoBehaviour
{

    public Text buildInfo;

    public List<string> infoDescription = new List<string>()
    {
        "Just a circle",
        "Circle That goes brrrrrr",
        "The circle... shall not... pass...",
        "Take control of the circle by WASD or arrow keys",
        "You might also want to try the mouse",
        "Wild squares have appeared!",
        "SQUARES, gotta catch 'em all,\nit's you and me\nI know it's my destiny....",
        "More SQUARE...",
        "Game of Magnet\nDifferent color attract each other, otherwise repel.\n\n" +
            "Collect square to earn 2 points; but if the square touches the black box, it is minus 1.\n\n" +
            "Press Space to gradually change color."
    };

    public void ShowInfo(int index)
    {
        buildInfo.text = infoDescription[index];
    }

    public void ClearInfo()
    {
        buildInfo.text = "";
    }
}
