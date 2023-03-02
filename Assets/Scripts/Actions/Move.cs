using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3;
    [SerializeField]
    private float minX = 2.1f;
    [SerializeField]
    private float maxX = 4.9f;
    [SerializeField]
    private float yOffset = 0.3f;
    [SerializeField]
    private float jumpYOffset = 0.5f;

    private bool isJumping = false;
    private bool isRolling = false;

    private Animator myAnimator;
    private BoxCollider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(minX + (maxX - minX) / 2, yOffset, 0);
        transform.Rotate(new Vector3(1, 0, 0), -20);
        myAnimator = gameObject.GetComponent<Animator>();
        myCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move to the sides
        float hInput = Input.GetAxis("Horizontal");
        float velocity = moveSpeed * Time.deltaTime;
        float newX = transform.position.x + hInput * velocity;
        if (newX > maxX) newX = maxX;
        if (newX < minX) newX = minX;
        float newY = transform.position.y;
        float newZ = transform.position.z;

        //Jump
        if (Input.GetButtonDown("Jump") && !isJumping && !isRolling)
        {
            isJumping = true;
            myAnimator.Play("Jump");
            myCollider.center = new Vector3(
                myCollider.center.x, 
                myCollider.center.y + jumpYOffset,
                myCollider.center.z);
        }
        if (isJumping)
        {
            if (myAnimator.IsInTransition(0)) 
            {
                isJumping = false;
                myCollider.center = new Vector3(
                    myCollider.center.x,
                    myCollider.center.y - jumpYOffset,
                    myCollider.center.z);

            }
        }

        //Roll
        if (Input.GetButtonDown("Roll") && !isJumping && !isRolling)
        {
            isRolling = true;
            myAnimator.Play("Roll");
        }
        if (isRolling)
        {
            if (myAnimator.IsInTransition(0)) isRolling = false;
        }

        //Fall
        if (LifeManager.Instance.GetIsFallen())
        {
            newY -= Time.fixedDeltaTime * (8 - moveSpeed);
        }

        //Reset position on restart
        if (LifeManager.Instance.isRestart)
        {
            newY = 0 + yOffset;
        }

        //Final position
        transform.position = new Vector3(newX, newY, newZ);


    }
}
