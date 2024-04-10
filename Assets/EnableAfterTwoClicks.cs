using UnityEngine;
using UnityEngine.UI; // Required for interacting with Buttons

public class ToggleEnableOnTwoClicks : MonoBehaviour
{
    public Button yourButton; // Assign this in the Inspector
    public GameObject objectToToggle; // Assign the GameObject you want to toggle in the Inspector

    private int clickCount = 0; // Keeps track of the number of button clicks

    void Start()
    {
        // Ensure that yourButton and objectToToggle are assigned
        if (yourButton == null || objectToToggle == null)
        {
            Debug.LogError("Button or Object to Toggle is not assigned.");
            return;
        }

        // Initially, you might want the object to be in a specific state (enabled or disabled)
        // For this example, let's start with it disabled
        objectToToggle.SetActive(false);

        // Add a listener to the button click event
        yourButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        clickCount++; // Increment the click count

        // Every two clicks, toggle the active state of the GameObject
        if (clickCount % 2 == 0)
        {
            // Toggle the GameObject's active state
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
