using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider speedSlider;
    public float speed;
    public int speedInt;

    private Rigidbody rb;
    private Renderer rend;
    private float moveHorizontal;
    private float moveVertical;
    private string ballColour;
    private string pastColour;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        rend = GetComponent<Renderer>();
        Debug.Log("Player 1 is blue");
    }

    void getBallColour()
    {
        if (isChanged()) // it goes to the method isChanged and if it is returned true it runs, if it returns false it doesn't run
        {
            Debug.Log("Player 1 is " + ballColour);
            // tells you which player is which colour in the console in unity, this is the script for player 1
            pastColour = ballColour;
            // after logging the colour it resets the past colour to the same so it only runs once
        }
    }

    public bool isChanged()
    {
        if (ballColour != pastColour) // if ball colour changed, it would be different from past colour when it gets to this code
                                      // because past colour doens't get set to ball colour until this is true
        {
            return true;
            // if it returns true it will go back to getBallColour and run the if statement            
        }
        return false;
        // if it returns false it will skip the if statement in getBallColour and run again next Fixed Update
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.right * -1 * speed);
        }

        if  (Input.GetKey(KeyCode.RightArrow))  
        {
            rb.AddForce(Vector3.right * speed);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.forward * -1 * speed);
        }
        getBallColour();
        // here it runs my code
    }

    public void ValueChangeCheck()
    {
        speed = speedSlider.value * 10;
        //speedInt = (int)speed;
        //Debug.Log("The speed value changed to " + speed.ToString() + " or " + speedInt.ToString() + " as an int.");
        switch ((int)speed)
        {
            case 0:
                rend.material.SetColor("_Color", Color.red);
                ballColour = "red";
                break;
            case 5:
                rend.material.SetColor("_Color", Color.yellow);
                ballColour = "yellow";
                break;
            case 10:
                rend.material.SetColor("_Color", Color.green);
                ballColour = "green";
                break;
        }

    }

}
