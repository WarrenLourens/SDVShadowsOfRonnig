using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidTouch : MonoBehaviour
{
    public float movement= 5000;
    public GameObject Character;
    private Rigidbody2D characterBody;
    private float ScreenWidth;
    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = Character.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                RunCharacter(1.0f);

            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                RunCharacter(-1.0f);
            }
            ++i;
        }

    }
    private void RunCharacter(float horizontalInput)
    {
        characterBody.AddForce(new Vector2(horizontalInput * movement * Time.deltaTime, 0));
     
    }
}
   
