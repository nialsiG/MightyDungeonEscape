using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject storyPanel;
    [SerializeField]
    private GameObject creditPanel;
    [SerializeField]
    private GameObject hallOfFamePanel;
    [SerializeField]
    private GameObject charSelectPanel;

    public enum myPanels
    {
        mainPanel,
        storyPanel,
        creditPanel,
        hallOfFamePanel,
        charSelectPanel
    }

    private List<GameObject> ListPanels;

    private void Start()
    {
        ListPanels = new List<GameObject>();
        ListPanels.Add(mainPanel);
        ListPanels.Add(storyPanel);
        ListPanels.Add(creditPanel);
        ListPanels.Add(hallOfFamePanel);
        ListPanels.Add(charSelectPanel);
    }

    private void OnClick(myPanels panel)
    {
        int index = (int)panel;
        if (!ListPanels[index].activeSelf) ListPanels[index].SetActive(true);
        else if (ListPanels[index].activeSelf) ListPanels[index].SetActive(false);
    }


    public void SetActiveMainPanel()
    {
        OnClick(myPanels.mainPanel);
    }
    public void SetActiveStory()
    {
        OnClick(myPanels.storyPanel);
    }
    public void SetActiveCredits()
    {
        OnClick(myPanels.creditPanel);
    }
    public void SetActiveHallOfFame()
    {
        OnClick(myPanels.hallOfFamePanel);
    }
    public void SetActiveCharSelect()
    {
        OnClick(myPanels.charSelectPanel);
    }


}
