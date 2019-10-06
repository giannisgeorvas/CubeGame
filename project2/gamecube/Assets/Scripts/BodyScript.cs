using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BodyScript : MonoBehaviour {

    public GameObject body;
    public GameObject camera;
    public GameObject fpsconroller;
    public List<GameObject> cubes;

    
    float currentpos;
    float updatepos;
    float difpos;
    int N;
    bool top;
    bool finishtop = false;

    // Use this for initialization
    void Start () {
        top = false;
        N = camera.GetComponent<UserInput>().N;
        this.cubes = camera.GetComponent<UserInput>().cubes;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // detect if fpscontroller fall out of range and return him back to magenta cube
        if (body.transform.position.y < 0)
        {
            currentpos = body.transform.position.y;
            Debug.Log("FALLING");
            camera.GetComponent<Score>().changeLifes(true);
            int N = camera.GetComponent<UserInput>().N;
            fpsconroller.transform.position = new Vector3(N/2, 2, N/2);
        }

        if (fpsconroller.GetComponent<FirstPersonController>().fall == true)
        {
            int scorelost = fpsconroller.GetComponent<FirstPersonController>().getReducedScore();
            camera.GetComponent<Score>().reduceScore(scorelost);
            Debug.Log("LOST: " + scorelost + "POINTS");
        }
        
        if(fpsconroller.GetComponent<FirstPersonController>().jump == true)
        {
            int scorelost = fpsconroller.GetComponent<FirstPersonController>().getReducedScore();
            camera.GetComponent<Score>().reduceScore(scorelost);
        }

        if (fpsconroller.transform.position.y >= N && top==false && finishtop==false)
        {
            Debug.Log("TOP");
            top = true;
            camera.GetComponent<Score>().points += 100;
            camera.GetComponent<Score>().life++;
            finishtop = true;
        }
        if (fpsconroller.transform.position.y < N)
        {
            top = false;
        }

    }

    
}
