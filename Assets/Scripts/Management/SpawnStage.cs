using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStage : MonoBehaviour
{
    public static SpawnStage Instance;

    [SerializeField]
    private GameObject WallsPrefab;
    [SerializeField]
    private GameObject[] StagePrefabs;
    [SerializeField]
    private GameObject[] CurrentStages;
    [SerializeField]
    private int NStages = 3;
    [SerializeField]
    private float TowerHeight = 14.4f;
    [SerializeField]
    private float StagePosition;

    private GameObject SpawnNewStage(int minRange, int maxRange)
    {
        int index = Util.RandomInt(minRange, maxRange);
        GameObject myField = Instantiate(StagePrefabs[index], new Vector3(0, StagePosition, 0), new Quaternion());
        GameObject walls = Instantiate(WallsPrefab, new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
        walls.transform.SetParent(myField.transform, false);
        return myField;
    }

    private void SetTheStage(int minRange, int maxRange)
    {         
        //Populate the scene with stages
        for (int i = 0; i < NStages; i++)
        {
            if (i == 1) CurrentStages[i] = SpawnNewStage(0, 0);
            else CurrentStages[i] = SpawnNewStage(minRange, maxRange);
            StagePosition += TowerHeight;
        }
        //Reset StagePosition for ingame spawning
        StagePosition -= TowerHeight;
    }

    private int[] GetLevelRange()
    {
        //Get difficulty level
        float currentScore = ServiceLocator.GetService<IScore>().GetScore();
        int difficultyLevel = (int)Mathf.Floor(currentScore / 500);
        int[] levelRange = new int[2];
        Debug.Log("levelRange(1): " + levelRange);
        Debug.Log("Difficulty level: " + difficultyLevel);
        if (difficultyLevel <= StagePrefabs.Length - 5)
        {
            levelRange[0] = 1 + difficultyLevel;
            levelRange[1] = 4 + difficultyLevel;
        }
        else if (difficultyLevel > StagePrefabs.Length - 5) //-4 levels of maxRange, -1 because start from 0
        {
            levelRange[0] = StagePrefabs.Length - 4; //-3 difference with maxRange, -1 because start from 0
            levelRange[1] = StagePrefabs.Length - 1; //-1 because start from 0
        }
        Debug.Log("levelRange(2): " + levelRange);
        return (levelRange);
    }

    void Awake()
    {
        //Singleton
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentStages = new GameObject[NStages];
        StagePosition -= TowerHeight;  //Since the camera is above, we need a tower stage below player
        //Get the current level range
        int[] myRange = GetLevelRange();
        SetTheStage(myRange[0], myRange[1]);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current stage's y = " + CurrentStages[0].transform.position.y);

        if (CurrentStages[0].transform.position.y < - 2 * TowerHeight)
        {
            //Get the current level range
            int[] myRange = GetLevelRange();
            //Remove the lowest stage
            GameObject level = CurrentStages[0];
            level.GetComponent<TowerRotation>().toDestroy = true;
            CurrentStages[0] = null;
            //Shift all prefabs in CurrentStages
            for (int i = 1; i < NStages; i++)
            {
                CurrentStages[i - 1] = CurrentStages[i];
            }
            CurrentStages[NStages - 1] = SpawnNewStage(myRange[0], myRange[1]);
        }
    }
}
