using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldDisplay;

    private int oldGold;
    private int newGold;

    private void Awake()
    {
    }

    private void Start()
    {
        oldGold = ServiceLocator.GetService<IGold>().GetGold();
        goldDisplay.SetText(oldGold.ToString());
    }

    private void Update()
    {
        newGold = ServiceLocator.GetService<IGold>().GetGold();

        if (oldGold != newGold)
        {
            goldDisplay.SetText(newGold.ToString());
            oldGold = newGold;
        }
    }

}
