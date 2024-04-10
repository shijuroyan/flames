using UnityEngine;
using TMPro;

public class FlamesCalculator : MonoBehaviour
{
    public TMP_InputField name1Input;
    public TMP_InputField name2Input;
    public TextMeshProUGUI resultText;
    public GameObject friendshipObject;
    public GameObject loveObject;
    public GameObject affectionObject;
    public GameObject marriageObject;
    public GameObject enmityObject;
    public GameObject sisterObject;

    public void CalculateFlames()
    {
        string name1 = name1Input.text.ToUpper();
        string name2 = name2Input.text.ToUpper();

        // Step 2: Cross out common letters
        string remainingLetters = RemoveCommonLetters(name1, name2);

        // Step 3: Count the remaining letters
        int count = remainingLetters.Length;

        // Step 4: Find the corresponding relationship status
        string relationshipStatus = GetRelationshipStatus(count);

        // Display the result
        resultText.text = " " + relationshipStatus;

        // Activate/Deactivate GameObjects based on the relationship status
        ActivateObjects(relationshipStatus);
    }

    private void ActivateObjects(string relationshipStatus)
    {
        friendshipObject.SetActive(relationshipStatus == "Friendship");
        loveObject.SetActive(relationshipStatus == "Love");
        affectionObject.SetActive(relationshipStatus == "Affection");
        marriageObject.SetActive(relationshipStatus == "Marriage");
        enmityObject.SetActive(relationshipStatus == "Enmity");
        sisterObject.SetActive(relationshipStatus == "Sister");
    }

    private string RemoveCommonLetters(string str1, string str2)
    {
        string result = "";

        foreach (char c in str1)
        {
            if (str2.Contains(c.ToString()))
            {
                str2 = str2.Remove(str2.IndexOf(c), 1);
            }
            else
            {
                result += c;
            }
        }

        result += str2;

        return result;
    }

    private string GetRelationshipStatus(int count)
    {
        string[] statuses = { "Friendship", "Love", "Affection", "Marriage", "Enmity", "Sister" };

        // FLAMES calculation
        while (statuses.Length > 1)
        {
            int index = (count - 1) % statuses.Length;
            statuses = RemoveAtIndex(statuses, index);
        }

        return statuses[0];
    }

    private string[] RemoveAtIndex(string[] array, int index)
    {
        string[] newArray = new string[array.Length - 1];
        int newArrayIndex = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[newArrayIndex++] = array[i];
            }
        }

        return newArray;
    }
}
