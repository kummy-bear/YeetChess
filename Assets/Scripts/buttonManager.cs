using UnityEngine;
using UnityEngine.UI;

public class ButtonNumberAssignment : MonoBehaviour
{
    public static bool buttFlag = false;
    public void AssignNumber(int number)
    {
        TextController.currentIndex = number;
        buttFlag = true;
    }
}
