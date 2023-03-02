using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Image image;
    [SerializeField]
    private int maxLife = 3;
    [SerializeField]
    private float invicibleTime = 1.5f;
    private float fallTime = 1.5f;
    private float timer = 0f;
    private float timer2 = 0f;

    protected int currentLife { get; private set; }
    public bool isFallen { get; private set; }
    public bool isRestart { get; private set; }
    public bool isInvincible { get; private set; }


    //Singleton
    public static LifeManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        isInvincible = false;
        currentLife = maxLife;
        UpdateLife();
    }

    public void Restart()
    {
        isFallen = false;
        Instance.isRestart = true;
        currentLife = maxLife;
        UpdateLife();
    }

    private void Update()
    {
        if (LifeManager.Instance.isInvincible)
        {
            timer += Time.deltaTime;

            if (timer > invicibleTime)
            {
                LifeManager.Instance.SwitchInvicibility();
                timer = 0f;
            }
        }

        if (LifeManager.Instance.isFallen)
        {
            timer2 += Time.deltaTime;
            
            if (timer2 > fallTime)
            {
                timer2 = 0;
                GameOver();
            }
        }
    }

    private void LateUpdate()
    {
        if (Instance.isRestart) Instance.isRestart = false;
    }

    public int GetCurrentLife()
    {
        return currentLife;
    }

    public bool GetIsFallen()
    {
        return isFallen;
    }

    public void SetIsFallen()
    {
        if (isFallen) isFallen = false;
        else isFallen = true;
    }

    public void SwitchInvicibility()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            Debug.Log("Invincible");
        }
        else
        {
            isInvincible = false;
            Debug.Log("Vulnerable");

        }
    }
    private void AddHeart(Color color, Vector3 position)
    {
        var createImage = Instantiate(image, position, new Quaternion()) as Image;
        createImage.transform.SetParent(panel.transform, false);
        createImage.color = color;
    }

    private void UpdateLife()
    {
        float imageWidth = image.rectTransform.rect.xMax - image.rectTransform.rect.xMin;
        float imageHeight = image.rectTransform.rect.xMax - image.rectTransform.rect.xMin;
        Vector2 displaySize = canvas.pixelRect.size;
        float originHeartX = - (imageWidth * maxLife / 2);

        Color myColor;
        for (int i = 0; i < maxLife; i++)
        {
            if (i < currentLife)
            {
                myColor = Color.white;
            }
            else
            {
                myColor = Color.black;
            }
            AddHeart(myColor, new Vector3(
                    originHeartX + i * (imageWidth + 10),
                    0f,
                    0f));
        }
    }

    public void LoseLife()
    {
        currentLife -= 1;
        UpdateLife();

        if (currentLife <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Player health = 0 ... GAME OVER!");
        ChangeScene _changeScene = GameObject.Find("GameManager").GetComponent<ChangeScene>();
        _changeScene.GameOver();
    }

}
