using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

    public Transform[] positions;
    public GameObject[] walls;

    string wallTag;
    Vector3 position;

    public wall(){

        this.wallTag = " ";
    }

    public wall(string name, Vector3 pos){

        this.wallTag = name;
        this.position = pos;
    }

    public string getWallTag() { return this.wallTag; }
    public Vector3 getPosition() { return this.position; }

    public void makeWall(){

        for (int i = 0; i < 21; i++)
        {
            int rand = Random.Range(0, 9);

            GameObject wall = Instantiate(walls[rand]);
            

            switch (rand)
            {
                case 0:
                    wall.tag = "smallhexagon";

                    break;
                case 1:
                    wall.tag = "wall";

                    break;
                case 2:
                    wall.tag = "smallsquare";

                    break;
                case 3:
                    wall.tag = "hexagon";


                    break;
                case 4:
                    wall.tag = "smallpentagon";

                    break;
                case 5:
                    wall.tag = "smallcircle";

                    break;
                case 6:
                    wall.tag = "smalltriangle";

                    break;
                case 7:
                    wall.tag = "circle";

                    break;
                case 8:
                    wall.tag = "pentagon";

                    break;
                case 9:
                    wall.tag = "square";

                    break;


            }

            wall.transform.rotation = Quaternion.Euler(-90, 0, 0);
            wall.transform.position = positions[i].position;
            wall.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);

        }
    }
}

