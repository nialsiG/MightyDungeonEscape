using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CharacterPrefabs;
    [SerializeField]
    private GameObject Parent;

    private int currentCharacter;
    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = ServiceLocator.GetService<IChar>().GetCharacter();
        GameObject character = Instantiate(CharacterPrefabs[currentCharacter], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        character.transform.SetParent(Parent.transform, false);
    }
}
