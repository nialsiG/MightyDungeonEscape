using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseText : MonoBehaviour
{
    [SerializeField]
    private TextAsset textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text textElement = gameObject.GetComponent<TMP_Text>();
        textElement.text = textToDisplay.ToString();
    }
}
