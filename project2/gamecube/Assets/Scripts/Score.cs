using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using System;

public class Score : MonoBehaviour {

    public GameObject fpscontroller;
    public TextMeshProUGUI score;
    public int health;
    public int life;
    public int fcubes;
    public int points ;
    public int fcylinder;
	
	void Start ()
    {
        points = 100;
        life = 4;
        fcubes = 0;
        fcylinder = 0;
	}
	
	void Update ()
    {
        /* Text of Points and Lifes */
        CanvaScore();

        /* Lose life Or End Of Game if points or lifes less than 0 */
        if (points < 0) {
            int hlp_points = Math.Abs(0 - points);
            life--;  
            points = 100 - hlp_points; 
        }
        if (life <= 0)
        {
            Destroy(fpscontroller);
        }
    }

    public void CanvaScore()
    {
        score.text = ("POINTS: " + points + "\t\t\t\t\t\t\t\t\t\t\t\t\t     LIFES: " + life );
    }

    public void changeScore(KeyCode key, Color otherColor)
    {
        /* if <P> pressed && hit yellow,red,green cube */
        if (key == KeyCode.P && otherColor!=Color.blue && otherColor!=Color.cyan) 
        {
            fcubes++;
            points -=5;
        }

        /* if <P> pressed && hit cyan */
        if (key == KeyCode.P && otherColor == Color.cyan) 
        {
            fcylinder++;
            points -= 5;
        }

        /* if <B> pressed */
        if (key == KeyCode.B  && fcubes>0) 
        {
            fcubes--;
            points += 10;
        }

        /* if <C> pressed */
        if (key == KeyCode.C)
        {
            points += 20;
            fcylinder--;
        }
    }

    /* Reduce Points if Player fall levels */
    public void reduceScore(int losePoints)
    {
        points -= losePoints;
    }

    /* Reduce Lifes if Player fall out of bounds */
    public void changeLifes(bool redInc)
    {
        if (redInc)
        {
            life -= 1;
        }
        if (!redInc)
        {
            life += 1;
        }
    }

    public bool getFcubes()
    {
        if (fcubes > 0) { return true; }
        return false;
    }

    public bool getFcylinder()
    {
        if (fcylinder > 0) { return true; }
        return false;
    }

}
