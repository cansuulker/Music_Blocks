using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using System.IO;

public class blocks : MonoBehaviour
{
    private float timer;
    public static bool spawned = false;
    public Stream filePath;

    public GameObject[] walls;
    public GameObject[] objects;
    public Transform[] positions;
    public GameObject dutyPanel;

    public Material Material1;
    public Material[] materials;
    public GameObject item;
    public static bool gameOver = false;
    public Font myFont;
    public static int sum;

    public GameObject particleEff;
    public GameObject soundObj;

    public bool playAudio = false;


    public List<GameObject> wall_list = new List<GameObject>();
    public static List<GameObject> object_list = new List<GameObject>();
    private List<bool> fullness_list = new List<bool>();
    public List<string> tags;
    private List<Transform> randomWallPositions = new List<Transform>();

    public GameObject currentObject;
    public int matchedObjects = 0;
    public List<int> wallCount = new List<int>();
    public List<int> objectCount = new List<int>();
    public static List<AudioSource> music = new List<AudioSource>();




    private GameObject GameData;
    private int numberOfHoles = 5;
    private float accuracy= 2;
    private int numberOfGames=5;
    private bool rotation=false;
    private bool arithmetics=true;
    private bool effects=true;
    private int numDigits=1;
    private int typeOperation=0;
    private int numOperands=2;
   



    // Use this for initialization
    void Start()
    {
        Debug.Log(Application.dataPath);
        /*GameData = GameObject.Find("GameController");
        numberOfHoles = GameData.GetComponent<setGameParameters>().numOfGames;
        accuracy = GameData.GetComponent<setGameParameters>().accuracy;
        rotation = GameData.GetComponent<setGameParameters>().rotation;
        arithmetics = GameData.GetComponent<setGameParameters>().arithmetics;
        effects = GameData.GetComponent<setGameParameters>().effects;
        numDigits = GameData.GetComponent<setGameParameters>().numDigits;
        typeOperation = GameData.GetComponent<setGameParameters>().typeOperation;
        numOperands = GameData.GetComponent<setGameParameters>().numOperands;*/
        numberOfHoles = GameSettings.numberOfGames;
        accuracy = GameSettings.accuracy;
        rotation = GameSettings.rotation;
        arithmetics = GameSettings.arithmetics;
        effects = GameSettings.effects;
        numDigits = GameSettings.numberOfDigits;
        typeOperation = GameSettings.typeOfOperation;
        numOperands = GameSettings.numberOfOperands;


        makeWall2();
        initializeLists(wallCount, objectCount);
        countShapeWalls();

        numberOfGames = numberOfHoles;
        currentObject = spawn();
        dutyPanel.SetActive(false);
        //countShapeObjects();

        particleEff.SetActive(false);
        ParticleSystem part = particleEff.GetComponentInChildren<ParticleSystem>();
        if (!part.isPlaying) part.Stop();
        //Cursor.lockState = CursorLockMode.Locked;
        Camera.main.GetComponent<objectClick>().enabled = false;

    }

    void initializeLists(List<int> list1, List<int> list2)
    {
        for (int i = 0; i < 10; i++)
        {
            list1.Add(0);
            list2.Add(0);
        }

        for (int i = 0; i < wall_list.Count; i++)
        {
            tags.Add(wall_list[i].tag);
        }
    }
    void countShapeWalls()
    {

        for (int i = 0; i < 21; i++)
        {
            if (wall_list[i].tag == "circle")
                wallCount[0]++;
            if (wall_list[i].tag == "pentagon")
                wallCount[1]++;
            if (wall_list[i].tag == "hexagon")
                wallCount[2]++;
            if (wall_list[i].tag == "square")
                wallCount[3]++;
            if (wall_list[i].tag == "smallsquare")
                wallCount[4]++;
            if (wall_list[i].tag == "smallpentagon")
                wallCount[5]++;
            if (wall_list[i].tag == "smallhexagon")
                wallCount[6]++;
            if (wall_list[i].tag == "smalltriangle")
                wallCount[7]++;
            if (wall_list[i].tag == "smallcircle")
                wallCount[8]++;
            if (wall_list[i].tag == "wall")
                wallCount[9]++;

        }
    }

    void setTag(GameObject game, int rand)
    {
        switch (rand)
        {
            case 0:
                game.tag = "circle";
                break;
            case 1:
                game.tag = "pentagon";
                break;
            case 2:
                game.tag = "hexagon";
                break;
            case 3:
                game.tag = "square";
                break;
            case 4:
                game.tag = "smallsquare";
                break;
            case 5:
                game.tag = "smallpentagon";
                break;
            case 6:
                game.tag = "smallhexagon";
                break;
            case 7:
                game.tag = "smalltriangle";
                break;
            case 8:
                game.tag = "smallcircle";
                break;

        }
    }
    void selectRandPositions() // for selecting #numOfHoles positions from positions[]
    {
        for (int i = 0; i < numberOfHoles; i++)
        {
            int rand = Random.Range(0, 21);
            Transform temp = positions[rand];

            while (randomWallPositions.Contains(temp))
            {

                rand = Random.Range(0, 21);
                temp = positions[rand];

            }

            randomWallPositions.Add(temp);

        }


    }

    GameObject spawn()
    {


        Debug.Log("spawn " + matchedObjects);
        int randObj = Random.Range(0, 9);

        GameObject obj = Instantiate(objects[randObj]);
        bool exists = false;

        while (exists == false)
        {
            setTag(obj, randObj);
            string val = obj.tag;
            int index = getIndex(val);
            if (!tags.Contains(val) || wallCount[index] <= 0)
            {
                randObj = Random.Range(0, 9);
                Destroy(obj);
                obj = Instantiate(objects[randObj]);
                setTag(obj, randObj);

            }
            else
            {
                exists = true;
                objectCount[index]++;

            }

        }
        if(!effects){
            obj.GetComponentInChildren<ParticleSystem>().Stop();
        }
        spawned = true;
        obj.transform.parent = item.transform;
        obj.transform.rotation = Quaternion.Euler(-90, 0, 0);
        obj.transform.position = new Vector3(Random.Range(-2, 8), Random.Range(3, -1), Random.Range(7, 7));

        for (int i = 0; i < 21; i++)
        {
            float dist;
            float xcor = positions[i].transform.position.x;
            float ycor = positions[i].transform.position.y;
            dist = Mathf.Sqrt((xcor - obj.transform.position.x) * (xcor - obj.transform.position.x) + (ycor - obj.transform.position.y) * (ycor - obj.transform.position.y));
            while (tags[i] == obj.tag && dist < 3)
            {
                obj.transform.position = new Vector3(Random.Range(-2, 8), Random.Range(3, -1), Random.Range(7, 7));
                dist = Mathf.Sqrt((xcor - obj.transform.position.x) * (xcor - obj.transform.position.x) + (ycor - obj.transform.position.y) * (ycor - obj.transform.position.y));

            }
        }
        int rand = Random.Range(0, 5);
        //obj.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        MeshRenderer renderer = obj.GetComponentInChildren<MeshRenderer>();
        renderer.material = materials[rand];


        keyboardControl keyboardComponent = obj.AddComponent<keyboardControl>();
        keyboardComponent.speed = 5;
        object_list.Add(obj);

        return obj;
    }
    int pos; // for the index of the wall in the numberOfWalls list
    void timerLogic()
    {
        timer += Time.deltaTime;
    }
    int getIndex(string tag)
    {
        if (tag == "circle")
            pos = 0;
        if (tag == "pentagon")
            pos = 1;
        if (tag == "hexagon")
            pos = 2;
        if (tag == "square")
            pos = 3;
        if (tag == "smallsquare")
            pos = 4;
        if (tag == "smallpentagon")
            pos = 5;
        if (tag == "smallhexagon")
            pos = 6;
        if (tag == "smalltriangle")
            pos = 7;
        if (tag == "smallcircle")
            pos = 8;

        return pos;


    }

    void makeWall2()
    {
        selectRandPositions();
        for (int i = 0; i < numberOfHoles; i++)
        {
            int rand = Random.Range(0, 9);
            GameObject wall = Instantiate(walls[rand]);

            switch (rand)
            {
                case 0:
                    wall.tag = "circle";
                    //numberOfWalls[0]++;
                    break;
                case 1:
                    wall.tag = "pentagon";
                    break;
                case 2:
                    wall.tag = "hexagon";
                    //numberOfWalls[2]++;
                    break;
                case 3:
                    wall.tag = "square";
                    // numberOfWalls[3]++;
                    break;
                case 4:
                    wall.tag = "smallsquare";
                    //numberOfWalls[4]++;
                    break;
                case 5:
                    wall.tag = "smallpentagon";
                    //numberOfWalls[5]++;
                    break;
                case 6:
                    wall.tag = "smallhexagon";
                    //numberOfWalls[6]++;
                    break;
                case 7:
                    wall.tag = "smalltriangle";
                    //numberOfWalls[7]++;
                    break;
                case 8:
                    wall.tag = "smallcircle";
                    //numberOfWalls[8]++;
                    break;

            }
            wall.transform.rotation = Quaternion.Euler(-90, 0, 0);
            wall.transform.position = randomWallPositions[i].position;

            wall.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);

            //wall.AddComponent<MeshRenderer>();
            MeshRenderer renderer = wall.GetComponentInChildren<MeshRenderer>();
            renderer.material = Material1;
            // wall.GetComponentInChildren<MeshRenderer>().materials[0] = Material1;
            wall_list.Add(wall);
            fullness_list.Add(false);
        }
        for (int j = 0; j < 21; j++)
        {
            if (!randomWallPositions.Contains(positions[j]))
            {
                GameObject plainWall = Instantiate(walls[9]);
                plainWall.transform.rotation = Quaternion.Euler(-90, 0, 0);
                plainWall.transform.position = positions[j].position;
                plainWall.tag = "wall";
                plainWall.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);

                //wall.AddComponent<MeshRenderer>();
                MeshRenderer renderer = plainWall.GetComponentInChildren<MeshRenderer>();
                renderer.material = Material1;
                wall_list.Add(plainWall);

            }
        }


    }
    public void Restart()
    {
        // destroyAllObjects();
        Start();

    }

    void onMatch2()
    {
        if (spawned)
            InvokeRepeating("timerLogic", 0.1f, 60.0f);

        for (int i = 0; i < randomWallPositions.Count; i++)
        {
            float distance;

            Vector3 wall_center = randomWallPositions[i].transform.position;
            Vector3 object_center = currentObject.transform.position;
            distance = Mathf.Sqrt((wall_center.x - object_center.x) * (wall_center.x - object_center.x) + (wall_center.y - object_center.y) * (wall_center.y - object_center.y));

            if (distance < accuracy && currentObject.tag == wall_list[i].tag && fullness_list[i] == false)
            {
               
   
                int rand = Random.Range(0, 14);
                if (!playAudio)
                {
                    /* source = Instantiate(audios[rand]);
                     music.Add(audios[rand]);*/
                    soundObj.GetComponent<audioController>().playNote();
                   
                }

                currentObject.transform.position = wall_center;
                ParticleSystem part = currentObject.GetComponentInChildren<ParticleSystem>();
                part.Stop();

                Destroy(currentObject.GetComponent<keyboardControl>());
                fullness_list[i] = true;

                //decrementWallNumber(wall_list[i].tag);
                matchedObjects++;
                int index = getIndex(wall_list[i].tag);
                wallCount[index]--;
                writePlay(currentObject, timer, true);
                if (matchedObjects < numberOfGames)
                {
                    StartCoroutine(waitforsecs());
                    spawned = false;
                    CancelInvoke("timerLogic");
                    timer = 0;
                    currentObject = spawn();
                    break;
                }
                else
                {
                    // attachNumber();
                    if(typeOperation == 0)
                        Camera.main.GetComponent<objectClick>().attachNumberAddition();
                    if(typeOperation == 1)
                        Camera.main.GetComponent<objectClick>().attachNumberSubtraction();
                    if(typeOperation == 2)
                        Camera.main.GetComponent<objectClick>().attachNumberMultiplication();

                    dutyPanel.SetActive(true);
                    gameOver = true;
                }
            }
        }
    }
   

    IEnumerator waitforsecs()
    {
        yield return new WaitForSeconds(2);

    }
    public static void writePlay(GameObject obj, float timeInSecs, bool success)
    {
        using (StreamWriter writer = new StreamWriter("/Users/cansuulker/musicblocks/liveData.csv", true))
        {
            var csvFileLength = new System.IO.FileInfo("/Users/cansuulker/musicblocks/liveData.csv").Length;

            //Vector3 objectcenter = obj.transform.position;
            //Vector3 wallcenter = wall.transform.position;
            //Vector3 dist = wallcenter - objectcenter;
            //float x_coor = objectcenter.x;
            //float y_coor = objectcenter.y;
            string objShape = obj.tag;

            if (csvFileLength == 0)
            {
                writer.WriteLine("object, success, time");
            }
            writer.WriteLine(objShape + ","
                             + success.ToString() + "," + timeInSecs);
            Debug.Log("written" + timeInSecs);
        }


    }

    void Update()
    {

        if (!gameOver)
        {
            playAudio = false;

            onMatch2();

        }
        else
        {
            //TODO gameover screen / restart

            Camera.main.GetComponent<objectClick>().enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Camera.main.GetComponent<blocks>().enabled = false;



        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //attachNumber();
        }


    }
}








