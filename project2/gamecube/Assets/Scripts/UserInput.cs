using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityStandardAssets.CrossPlatformInput;

public class UserInput : MonoBehaviour
{
    public GameObject UI;
    public Camera camera;
    public InputField Placeholder;
    public int N;
    public GameObject cube;
    public GameObject centralcube;
    public Light spotlight;
    public CharacterController fpscontroller;
    public GameObject player;
    public GameObject bound;
    public List<GameObject> cubes = new List<GameObject>();

    // Use this for initialization
    void Start()
    {         

    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.M)){
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            /* ONLY POSITIVE SIZE AND BIGGER THAN 10 */
            N = int.Parse(Placeholder.text);    
            N=Mathf.Abs(N);

            if (N < 8) { N = 8; }

            UI.SetActive(false);       // disable starting window   

            /* BOUNDARIES CODE START */
            GameObject bound1 = Instantiate(bound, new Vector3(0, 0, -1f), Quaternion.Euler(90, 0, 0));
            GameObject bound2 = Instantiate(bound, new Vector3(0, 0, N), Quaternion.Euler(90, 0, 0));
            GameObject bound3 = Instantiate(bound, new Vector3(N, 0, 0), Quaternion.Euler(0, 0, 90));
            GameObject bound4 = Instantiate(bound, new Vector3(-1f, 0, N), Quaternion.Euler(0, 0, 90));
            GameObject top = Instantiate(bound, new Vector3(0, N+2, 0), Quaternion.Euler(0, 0, 180));
            top.GetComponent<MeshRenderer>().material.color = Color.red;

            bound1.transform.localScale = new Vector3(N * 10, 1, N * 10);
            bound2.transform.localScale = new Vector3(N * 10, 1, N * 10);
            bound3.transform.localScale = new Vector3(N * 10, 1, N * 10);
            bound4.transform.localScale = new Vector3(N * 10, 1, N * 10);
            top.transform.localScale = new Vector3(N * 10, 1, N * 10);
            /* BOUNDARIES CODE END */

            /* SET GROUND */
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == N/2 && j == N / 2)
                    {
                        cubes.Add(Instantiate(centralcube, new Vector3(i, 1, j), Quaternion.identity));
                    }
                    else
                    {
                        cubes.Add(Instantiate(cube, new Vector3(i, 1, j), Quaternion.identity));
                    }
                }
            }
            

            /* TESTING 
            for(int i=0; i<N; i++)
            {
                Instantiate(cube, new Vector3(i, i, 4), Quaternion.identity);
            }
            END TESTING */

            /* LIGHTS */
            Light light1 = Instantiate(spotlight, new Vector3(0, N, 0), Quaternion.Euler(45, 45, 0));
            if (N >= 15) { light1.range *= N/10; }
            Light light2 = Instantiate(spotlight, new Vector3(N, N, N), Quaternion.Euler(45, -135, 0));  //TODO check for tiny and huge terrain
            if (N >= 15) { light2.range *= N/10; }

            
            /* CHARACTER IN SCENE */
            player.transform.position = new Vector3(N / 2, 2, N / 2);
            player.SetActive(true);

            Character character = camera.GetComponent<Character>();
            character.enabled = true;

        }	
	}
}
