using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectClick : MonoBehaviour
{
    public static objectClick instance;
    public GameObject dutyPanel;
    public Text outText;
    public int numberOfObjectsToClick;
    public List<GameObject> clickedObjects;
    public List<Material> clickedMaterials;
    public int numOfGames;
    public GameObject particleEff;
    public Material mat;
    public List<GameObject> object_list = blocks.object_list;
    public List<int> numbers = new List<int>();
    public Font myFont;


    private List<int> clickedNumbers = new List<int>();
    private int sum = blocks.sum;
    private bool answeredRight = false;
    private bool answeredWrong = false;
    private bool gameOver = false;
    private bool turnOver = false;
    private int rightAnswer = 0;
    private int clicks = 0;
    private int[] randIndexes;
    private HashSet<int> hash = new HashSet<int>();
    private int numOperands;
    private int numDigits;
    private int typeOperation;
    private bool effects;
    private List<int> oldSums = new List<int>();

    IEnumerator waitforsecs()
    {
        yield return new WaitForSeconds(10);

    }

    IEnumerator sendMessage(string message)
    {
        outText.text = message;
        Debug.Log(message);
        if(message == "TEBRIKLER")
        {
            answeredRight = true;
            answeredWrong = false;
            rightAnswer++;

        }
        if(message == "TEKRAR DENE")
        {
            answeredRight = false;
            answeredWrong = true;
            for (int i = 0; i < clickedObjects.Count; i++)
            {
                MeshRenderer renderer = clickedObjects[i].GetComponentInChildren<MeshRenderer>();
                renderer.material = clickedMaterials[i];

            }

            clickedObjects.Clear();
            clickedNumbers.Clear();
            clickedMaterials.Clear();
            clicks = 0;
        }
        if(message == "objeye tikla")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject obj = hit.collider.gameObject;
                Debug.Log(hit.transform.gameObject.tag);
                obj = hit.collider.gameObject;
            }
        }
        yield return new WaitForSeconds(5);


    }
    IEnumerator playEffect()
    {
        ParticleSystem partc = particleEff.GetComponentInChildren<ParticleSystem>();
        partc.Play();
        particleEff.SetActive(true);

        yield return new WaitForSeconds(10);
    }
    public void addition()
    {
        int[] result = new int[numOperands];
        int left = sum - numOperands * (numOperands + 1) / 2;

        for (int i = 0; i < numOperands; i++)
        {
            result[i] = i + 1 + left / numOperands;
            if (i >= numOperands - (left % numOperands))
            {//Add extra one for last left % n elements
                result[i]++;
            }
        }
    }
    public void attachNumberMultiplication()
    {
        TextMesh panelTxt = dutyPanel.GetComponentInChildren<TextMesh>();
        sum = Random.Range(2, 18);
        panelTxt.text = sum.ToString();
        int randIndex = Random.Range(0, object_list.Count);
        int randIndex2 = Random.Range(0, object_list.Count);
        while (randIndex == randIndex2)
        {
            randIndex = Random.Range(0, object_list.Count);
        }

        Canvas canvas = object_list[randIndex].GetComponentInChildren<Canvas>();
        Text txt = canvas.GetComponentInChildren<Text>();
        Canvas canvas2 = object_list[randIndex2].GetComponentInChildren<Canvas>();
        Text txt2 = canvas2.GetComponentInChildren<Text>();
        bool nonzero = false;

        int rand = 0;
        int otherNumber = 0;

        while (!nonzero)
        {
            rand = Random.Range(1, 10);
            otherNumber = sum / rand;
            if (otherNumber > 0)
                nonzero = true;
        }
        string str = rand.ToString();
        string str2 = otherNumber.ToString();

        txt.text = str;
        txt2.text = str2;

        txt.font = myFont;
        txt.fontSize = 55;
        txt2.font = myFont;
        txt2.fontSize = 55;

        numbers.Add(int.Parse(str));
        numbers.Add(int.Parse(str2));

        for (int i = 0; i < object_list.Count; i++)
        {
            if (i != randIndex && i != randIndex2)
            {
                Canvas can = object_list[i].GetComponentInChildren<Canvas>();
                Text text = can.GetComponentInChildren<Text>();
                int randomN = Random.Range(1, 10);
                string s1 = randomN.ToString();
                text.text = s1;
                text.font = myFont;
                text.fontSize = 55;

                numbers.Add(int.Parse(s1));
            }
        }
    }
    public void attachNumberSubtraction()
    {
        TextMesh panelTxt = dutyPanel.GetComponentInChildren<TextMesh>();
        sum = Random.Range(2, 18);
        panelTxt.text = sum.ToString();
        int randIndex = Random.Range(0, object_list.Count);
        int randIndex2 = Random.Range(0, object_list.Count);
        while (randIndex == randIndex2)
        {
            randIndex = Random.Range(0, object_list.Count);
        }

        Canvas canvas = object_list[randIndex].GetComponentInChildren<Canvas>();
        Text txt = canvas.GetComponentInChildren<Text>();
        Canvas canvas2 = object_list[randIndex2].GetComponentInChildren<Canvas>();
        Text txt2 = canvas2.GetComponentInChildren<Text>();
        bool nonzero = false;

        int rand = 0;
        int otherNumber = 0;

        while (!nonzero)
        {
            rand = Random.Range(1, 10);
            otherNumber = sum + rand;
            if (otherNumber > 0)
                nonzero = true;
        }
        string str = rand.ToString();
        string str2 = otherNumber.ToString();

        txt.text = str;
        txt2.text = str2;

        txt.font = myFont;
        txt.fontSize = 55;
        txt2.font = myFont;
        txt2.fontSize = 55;

        numbers.Add(int.Parse(str));
        numbers.Add(int.Parse(str2));

        for (int i = 0; i < object_list.Count; i++)
        {
            if (i != randIndex && i != randIndex2)
            {
                Canvas can = object_list[i].GetComponentInChildren<Canvas>();
                Text text = can.GetComponentInChildren<Text>();
                int randomN = Random.Range(1, 10);
                string s1 = randomN.ToString();
                text.text = s1;
                text.font = myFont;
                text.fontSize = 55;

                numbers.Add(int.Parse(s1));
            }
        }
    }

    public void attachNumberAddition()
    {
        TextMesh panelTxt = dutyPanel.GetComponentInChildren<TextMesh>();
        sum = Random.Range(2, 18);
        panelTxt.text = sum.ToString();

        int randIndex = Random.Range(0, object_list.Count);
        int randIndex2 = Random.Range(0, object_list.Count);
        while (randIndex == randIndex2)
        {
            randIndex = Random.Range(0, object_list.Count);
        }

        Canvas canvas = object_list[randIndex].GetComponentInChildren<Canvas>();
        Text txt = canvas.GetComponentInChildren<Text>();
        Canvas canvas2 = object_list[randIndex2].GetComponentInChildren<Canvas>();
        Text txt2 = canvas2.GetComponentInChildren<Text>();
        bool nonzero = false;

        int rand = 0;
        int otherNumber = 0;

        while (!nonzero)
        {
            rand = Random.Range(1, sum);
            otherNumber = sum - rand;
            if (otherNumber > 0)
                nonzero = true;
        }
        string str = rand.ToString();
        string str2 = otherNumber.ToString();

        txt.text = str;
        txt2.text = str2;

        txt.font = myFont;
        txt.fontSize = 55;
        txt2.font = myFont;
        txt2.fontSize = 55;

        numbers.Add(int.Parse(str));
        numbers.Add(int.Parse(str2));

        for (int i = 0; i < object_list.Count; i++)
        {
            if (i != randIndex && i != randIndex2)
            {
                Canvas can = object_list[i].GetComponentInChildren<Canvas>();
                Text text = can.GetComponentInChildren<Text>();
                int randomN = Random.Range(1, 10);
                string s1 = randomN.ToString();
                text.text = s1;
                text.font = myFont;
                text.fontSize = 55;

                numbers.Add(int.Parse(s1));
            }
        }
    }


    void init(List<GameObject> items, List<Material> oldMaterials)
    {
        clicks = 0;
        clickedNumbers.Clear();

        particleEff.SetActive(false);

        for (int i = 0; i < clickedObjects.Count; i++)
        {
            MeshRenderer renderer = clickedObjects[i].GetComponentInChildren<MeshRenderer>();
            renderer.material = clickedMaterials[i];

        }

        clickedObjects.Clear();
        clickedMaterials.Clear();
        TextMesh paneltext = dutyPanel.GetComponentInChildren<TextMesh>();
        if (turnOver)
        {
            sum = Random.Range(2, 18);
            paneltext.text = sum.ToString();
            attachNumberAddition();
        }
        turnOver = false;
    }

    void Start()
    {

        instance = GetComponent<objectClick>();
        numOfGames = GameSettings.numberOfOperations;
        typeOperation = GameSettings.typeOfOperation;
        numDigits = GameSettings.numberOfDigits;
        numOperands = GameSettings.numberOfOperands;
        effects = GameSettings.effects;
        // numOfGames = GameObject.Find("GameController").GetComponent<setGameParameters>().numOfOperations;
        //typeOperation = GameObject.Find("GameController").GetComponent<setGameParameters>().typeOperation;
       // numDigits = GameObject.Find("GameController").GetComponent<setGameParameters>().numDigits;

       // numOperands = GameObject.Find("GameController").GetComponent<setGameParameters>().numOperands;
        //effects = GameObject.Find("GameController").GetComponent<setGameParameters>().effects;

        // particleEff.SetActive(true);

    }

    void calculateResult(RaycastHit hit)
    {

        Cursor.lockState = CursorLockMode.Locked;
        // addNumbers(clickedNumbers, numberOfObjectsToClick);
        int checkResult = 0;
        switch(typeOperation)
        {
            case 0:

                for (int i = 0; i < numberOfObjectsToClick; i++)
                    checkResult += clickedNumbers[i];

                break;
            case 1:
                checkResult = clickedNumbers[0] - clickedNumbers[1];
                break;
            case 2:
                checkResult = 1;
                for (int i = 0; i < numberOfObjectsToClick; i++)
                    checkResult *= clickedNumbers[i];
                break;


        }
      


        if (checkResult == sum)
        {
            turnOver = true;
            particleEff.SetActive(true);
            ParticleSystem part = particleEff.GetComponentInChildren<ParticleSystem>();
            if (!part.isPlaying) StartCoroutine(playEffect());
            // outputText.SetActive(true);
            StartCoroutine(sendMessage("TEBRIKLER"));

      

        }
        else
        {
            // outputText.SetActive(true);
            StartCoroutine(sendMessage("TEKRAR DENE"));


        }

        if (rightAnswer <= numOfGames)
        {
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(waitforsecs());
            TextMesh paneltext = dutyPanel.GetComponentInChildren<TextMesh>();
            if (!answeredWrong && answeredRight)
            {
                turnOver = true;
                init(clickedObjects, clickedMaterials);
                switch(typeOperation)
                {
                    case 0:
                        attachNumberAddition();
                        break;
                    case 1:
                        attachNumberSubtraction();
                        break;
                    case 2:
                        attachNumberMultiplication();
                        break;
                }
               
            }
           


        }
        else
        {
            gameOver = true;
        }



    }
    IEnumerator changeMaterial(GameObject obj)
    {
        MeshRenderer renderer = obj.GetComponentInChildren<MeshRenderer>();
        Material oldMaterial = renderer.material;
        renderer.material = mat;
        clickedObjects.Add(obj);
        clickedMaterials.Add(oldMaterial);

        Text txt = obj.GetComponentInChildren<Text>();
        clicks++;

        Debug.Log(txt.text);
        int clickedNum = int.Parse(txt.text);
        clickedNumbers.Add(clickedNum);
        yield return new WaitForSeconds(5);

    }
    void clickOnObjects()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            particleEff.SetActive(false);

            Debug.Log(hit.transform.gameObject.tag);
            GameObject obj = hit.collider.gameObject;
            if(obj.tag == "wall")
            {
                StartCoroutine(sendMessage("objeye tikla"));

            }
            else{
                //MeshRenderer renderer = obj.GetComponentInChildren<MeshRenderer>();
                //Material oldMaterial = renderer.material;
                //renderer.material = mat;
                //clickedObjects.Add(obj);
                //clickedMaterials.Add(oldMaterial);

                //Text txt = obj.GetComponentInChildren<Text>();
                //clicks++;

                //Debug.Log(txt.text);
                //int clickedNum = int.Parse(txt.text);
                //clickedNumbers.Add(clickedNum);

                StartCoroutine(changeMaterial(obj));

                if (clicks == numberOfObjectsToClick)
                {
                    calculateResult(hit);

                }
                /*if (answeredRight)
                    StartCoroutine(sendMessage("TEBRİKLER"));
                if (answeredWrong)
                    StartCoroutine(sendMessage("TEKRAR DENE"));*/


                else
                {
                    Debug.Log("click one more object");
                    outText.text = "BIR OBJEYE DAHA TIKLA";
                }

            }

        }

    }

    void Update()
    {
        if(!gameOver){
            if (Input.GetMouseButtonDown(0))
                clickOnObjects();

        }
        else{
            Cursor.lockState = CursorLockMode.None;

            GUIManager.instance.activateGameOverMenu();
        }
            


    }
}

