using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(3);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Move(4);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Move(5);
        }

    }



    void Move(int n)
    {
        if (n == 0)
        { // forward
            GetComponent<Transform>().Translate(new Vector3(-1, 0, 0), Space.World);
        }
        if (n == 1)
        { // backward
            this.GetComponent<Transform>().position += new Vector3(1, 0, 0);
        }
        if (n == 2)
        { // left
            this.GetComponent<Transform>().position += new Vector3(0, 0, -1);
        }
        if (n == 3)
        { // right
            this.GetComponent<Transform>().position += new Vector3(0, 0, 1);
        }
        if (n == 4)
        { // upward
            this.GetComponent<Transform>().position += new Vector3(0, 1, 0);
        }
        if (n == 5)
        { // downward
            this.GetComponent<Transform>().position += new Vector3(0, -1, 0);
        }

    }
}

