using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Character : MonoBehaviour {

    public Ray ray;
    public Score score;
    public Color hitColor;
    public string hitTransformBefore;
    public bool checkOverCube;
    public bool checkOverCyl;
    public GameObject cube;
    public GameObject cylinder;
    public GameObject body;
    public Camera camera;
    public CharacterController player;
    public GameObject pl2;
    public List<GameObject> cubes;
    public List<GameObject> cylinders;
    public Image aim;

    // Use this for initialization
    void Start () {
        this.cubes = camera.GetComponent<UserInput>().cubes;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        aim.GetComponent<Image>().color = Color.black;

        if (Physics.Raycast(ray, out hit, 3))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);

            if (hit.collider.gameObject.tag=="Cube" || hit.collider.gameObject.tag == "Cylinder")
            {
                aim.GetComponent<Image>().color = Color.green; 
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (hit.collider.gameObject.name != null)
                {
                    hitColor = hit.collider.gameObject.GetComponent<CubeScript>().fund();
                    int y_cord = (int)hit.collider.gameObject.transform.position.y; // keeping y of cube
                    gameObject.GetComponent<Score>().changeScore(KeyCode.P, hitColor);
                    if (hitColor == Color.cyan)
                    {
                        Destroy(hit.collider.gameObject);
                        cubes.Remove(hit.collider.gameObject);

                        /* Searching the cube under cyan cube which destroyed and make cubeOver variable = false; */
                        for (int i = 0; i < cubes.Count; i++)
                        {
                            if ((int)cubes[i].transform.position.y == y_cord - 1)
                            {
                                cubes[i].GetComponent<CubeScript>().cubeOver = false;
                            }
                        }
                        for (int i = 0; i < cylinders.Count; i++)
                        {
                            if (Math.Abs((int)cylinders[i].transform.position.y) == y_cord - 3)
                            {
                                cylinders[i].GetComponent<CylinderScript>().cylOver = false;
                            }
                        }
                        /* If not exist a cube under cyan cube do nothing */
                    }
                }
            }

            // add a CUBE...IF FCUBES EXIST
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (gameObject.GetComponent<Score>().getFcubes() == true)
                {
                    int bodyGround = (int)body.transform.position.y;
                    int vectroGround = (int)hit.collider.gameObject.transform.position.y;

                    if (vectroGround - bodyGround > 1)
                    {
                        Debug.Log("YOU CANT ADD CUBE!");
                    }

                    if (vectroGround - bodyGround == 1)
                    {
                        Vector3 vector = hit.collider.gameObject.transform.position;
                        bool cubeOver = hit.collider.GetComponent<CubeScript>().cubeOver;
                        vector.y++;

                        if (cubeOver == false)
                        {
                            GameObject thecube = Instantiate(cube, vector, Quaternion.identity);
                            thecube.GetComponent<CubeScript>().cubeOver = true;
                            hit.collider.GetComponent<CubeScript>().cubeOver = true;
                            gameObject.GetComponent<Score>().changeScore(KeyCode.B, hitColor);
                            cubes.Add(thecube); // add cube to list of cubes
                        }

                    }

                    if (vectroGround - bodyGround == 0)
                    {
                        if (hit.collider.gameObject.tag == "Cube")
                        {
                            Vector3 vector = hit.collider.gameObject.transform.position; // position of ground
                            bool cubeOver = hit.collider.GetComponent<CubeScript>().cubeOver;
                            vector.y++;
                            if (cubeOver == false)
                            {
                                GameObject thecube = Instantiate(cube, vector, Quaternion.identity);
                                thecube.GetComponent<CubeScript>().cubeOver = true;
                                hit.collider.GetComponent<CubeScript>().cubeOver = true;
                                gameObject.GetComponent<Score>().changeScore(KeyCode.B, hitColor);
                                cubes.Add(thecube); // add cube to list of cubes
                            }
                        }
                        if (hit.collider.gameObject.tag == "Cylinder")
                        {
                            Debug.Log("FOUND CYL TAG");
                            Vector3 vector = hit.collider.gameObject.transform.position; // position of ground
                            vector.y += 3;
                            bool cylOver = hit.collider.GetComponent<CylinderScript>().cylOver;
                            Debug.Log(cylOver);
                            if (cylOver == false)
                            {
                                GameObject thecube = Instantiate(cube, vector, Quaternion.identity);
                                thecube.GetComponent<CubeScript>().cubeOver = true;
                                hit.collider.GetComponent<CylinderScript>().cylOver = true;
                                gameObject.GetComponent<Score>().changeScore(KeyCode.B, hitColor);
                                cubes.Add(thecube); // add cube to list of cubes
                            }
                        }
                    }

                    if (vectroGround - bodyGround == -1)
                    {
                        if (hit.collider.gameObject.tag == "Cylinder")
                        {
                            Vector3 vector = hit.collider.gameObject.transform.position; // position of ground
                            vector.y += 3;
                            bool cylOver = hit.collider.GetComponent<CylinderScript>().cylOver;
                            Debug.Log(cylOver);
                            if (cylOver == false)
                            {
                                GameObject thecube = Instantiate(cube, vector, Quaternion.identity);
                                thecube.GetComponent<CubeScript>().cubeOver = true;
                                hit.collider.GetComponent<CylinderScript>().cylOver = true;
                                gameObject.GetComponent<Score>().changeScore(KeyCode.B, hitColor);
                                cubes.Add(thecube); // add cube to list of cubes
                            }
                        }
                    }

                    if (vectroGround - bodyGround == -2)
                    {
                        if (hit.collider.gameObject.tag == "Cylinder")
                        {
                            Vector3 vector = hit.collider.gameObject.transform.position; // position of ground
                            vector.y += 3;

                            bool cylOver = hit.collider.GetComponent<CylinderScript>().cylOver;
                            Debug.Log(cylOver);
                            if (cylOver == false)
                            {
                                GameObject thecube = Instantiate(cube, vector, Quaternion.identity);
                                hit.collider.GetComponent<CylinderScript>().cylOver = true;
                                gameObject.GetComponent<Score>().changeScore(KeyCode.B, hitColor);
                                cubes.Add(thecube);
                            }

                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (gameObject.GetComponent<Score>().getFcylinder() == true)
                {
                    int bodyGround = (int)body.transform.position.y;
                    int vectroGround = (int)hit.collider.gameObject.transform.position.y;
                    bool checkOverCube = hit.collider.gameObject.GetComponent<CubeScript>().cubeOver; //should be false if dif = 0;

                    if (vectroGround - bodyGround > 1)
                    {
                        Debug.Log("YOU CANT ADD CYLINDER!");
                    }

                    if (vectroGround - bodyGround == 1)
                    {
                        Vector3 vector = hit.collider.gameObject.transform.position;
                        bool cubeOver = hit.collider.GetComponent<CubeScript>().cubeOver;
                        vector.y++;
                        if (cubeOver == false)
                        {
                            Vector3 vectorc = hit.collider.gameObject.transform.position;
                            vector.y++;
                            cylinder = Instantiate(cylinder, vectorc, Quaternion.identity);
                            gameObject.GetComponent<Score>().changeScore(KeyCode.C, hitColor);
                            cylinders.Add(cylinder);
                        }
                    }

                    if (vectroGround - bodyGround == 0)
                    {
                        Vector3 vector = hit.collider.gameObject.transform.position; // position of ground
                        bool cubeOver = hit.collider.GetComponent<CubeScript>().cubeOver;
                        vector.y++;
                        if (cubeOver == false)
                        {
                            Vector3 vectorc = hit.collider.gameObject.transform.position;
                            vector.y++;
                            cylinder = Instantiate(cylinder, vectorc, Quaternion.identity);
                            gameObject.GetComponent<Score>().changeScore(KeyCode.C, hitColor);
                            hit.collider.GetComponent<CubeScript>().cubeOver = true;
                            cylinders.Add(cylinder);
                        }
                    }


                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {

                if (hit.collider.gameObject.tag == "Cube" && hit.collider.gameObject.tag != "CentralCube")
                {
                    Destroy(hit.collider.gameObject);
                    cubes.Remove(hit.collider.gameObject);
                    int y_cord = (int)hit.collider.gameObject.transform.position.y; // keeping y of cube

                    /* Searching the cube under cyan cube which destroyed and make cubeOver variable = false; */
                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if ((int)cubes[i].transform.position.y == y_cord - 1)
                        {
                            cubes[i].GetComponent<CubeScript>().cubeOver = false;
                        }
                    }
                    for (int i = 0; i < cylinders.Count; i++)
                    {
                        if (Math.Abs((int)cylinders[i].transform.position.y) == y_cord - 3)
                        {
                            cylinders[i].GetComponent<CylinderScript>().cylOver = false;
                        }
                    }
                    /* If not exist a cube under cyan cube do nothing */
                }
            }
                
        }
        
    }       
}
