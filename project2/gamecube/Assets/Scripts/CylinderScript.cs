using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {

    public bool cylOver;
    Renderer m_Renderer;
    public Color color;

    // Use this for initialization
    void Start () {

        cylOver = false;
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.color = Color.cyan;

        color = Color.cyan;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
