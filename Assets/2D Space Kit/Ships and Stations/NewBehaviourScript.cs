using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] bgs;
    void Start()
    {
        bgs = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            bgs[i] = GameObject.Find("background" + i);
        }
        for (int i = -1; i <= 1; i++)
        {
            bgs[i].transform.position = new Vector3(0, bgs[i].transform.lossyScale.y * i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
