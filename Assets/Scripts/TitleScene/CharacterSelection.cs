using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefabs;

    private GameObject currentModel;
    private int CurrentCharacter;
    private int NChar;

    private void Start()
    {
        NChar = characterPrefabs.Length;
    }

    // Start is called before the first frame update
    public void OpenCharSelection()
    {
        CurrentCharacter = 0;
        currentModel = InstantiateCharModel();
        Debug.Log("Character selection opened");
    }

    public void CloseCharSelection()
    {
        Destroy(currentModel);
        Debug.Log("Character selection closed");
    }

    private void ChangeCharacter(int increment)
    {
        CurrentCharacter += increment;
        if (CurrentCharacter >= NChar) CurrentCharacter = 0;
        if (CurrentCharacter < 0) CurrentCharacter = NChar - 1;
        currentModel = InstantiateCharModel();
        Debug.Log("New Character Instanstiated, currentChar = " + CurrentCharacter);
    }

    private GameObject InstantiateCharModel()
    {
        Quaternion turn180 = new Quaternion();
        turn180.eulerAngles = new Vector3(0, 180, 0);
        GameObject myModel = Instantiate(characterPrefabs[CurrentCharacter], new Vector3(0, 0, 0), turn180);
        return myModel;
    }

    public void MoveSelectionToLeft()
    {
        Destroy(currentModel);
        ChangeCharacter(- 1);
    }

    public void MoveSelectionToRight()
    {
        Destroy(currentModel);
        ChangeCharacter(1);
    }

    public int GetCurrentSelection()
    {
        return CurrentCharacter;
    }
}
