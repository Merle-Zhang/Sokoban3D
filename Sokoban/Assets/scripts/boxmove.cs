using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        pos.x = (int)(pos.x + 0.2);
        pos.y = (int)(pos.y + 0.2);
        pos.z = (int)(pos.z + 0.2);
		GetComponent<Transform>().position = pos;
    }
}
