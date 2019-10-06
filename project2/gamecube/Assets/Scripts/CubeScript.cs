using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class CubeScript : MonoBehaviour {

    Renderer m_Renderer;
    public int color;
    public int cubeFund;
    public int cylinderFund;
    public bool cubeOver;
    public GameObject thiscube;
    public string name = "Cube";


    public string getName()
    {
        return this.name;
    }

    // Use this for initialization
    void Start()
    {
        cubeOver = false;

        m_Renderer = GetComponent<Renderer>();
    
        color = Random.Range(1, 6);
        if (color == 1)
        {
            m_Renderer.material.color = Color.red;
            cubeFund = 2;
        }
        if (color == 2)
        {
            m_Renderer.material.color = Color.blue;
            cubeFund = 0;
        }
        if (color == 3)
        {
            m_Renderer.material.color = Color.green;
            cubeFund = 3;
        }
        if (color == 4)
        {
            m_Renderer.material.color = Color.yellow;
            cubeFund = 1;
        }
        if (color == 5)
        {
            m_Renderer.material.color = Color.cyan;
            cylinderFund = 1;
        }
    }
         // Update is called once per frame
    void Update () {
       
	}

    public Color fund()
    {
        // save old color for returning at the end of function

        Color returnColor = m_Renderer.material.color;
        if (cubeFund == 1) // was yellow
        {
           cubeFund--; // change to blue
            m_Renderer.material.color = Color.blue;
        }
        if (cubeFund == 2) // was red
        {
            cubeFund--; // change to yellow
            m_Renderer.material.color = Color.yellow;
        }
        if (cubeFund == 3) // was green
        {
            cubeFund--; // change to red
            m_Renderer.material.color = Color.red;
        }

        return returnColor;
    }

    public float getCollisionY()
    {
        return thiscube.transform.position.y;
    }

   
}
