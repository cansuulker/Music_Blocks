using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
    public GameObject cubePrefab;

    public Vector3 center;
    public Vector3 size;
 
    private Transform[] transforms;
    public GameObject planeParent; 

    // Use this for initialization
    void Start () {
        transforms = planeParent.GetComponentsInChildren<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            spawnObject();
	}
    public void spawnObject(){
        //Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject newObj = Instantiate(cubePrefab);
        int rand = Random.Range(1, 9);
        Debug.Log(rand);
        Transform spawnPlaneTrans = transforms[rand];
        float randPosX = Random.Range(newObj.transform.lossyScale.x, spawnPlaneTrans.lossyScale.x *5  - newObj.transform.lossyScale.x);
        float randPosY = Random.Range(newObj.transform.lossyScale.z, spawnPlaneTrans.lossyScale.z *5 - newObj.transform.lossyScale.z);
        randPosX += spawnPlaneTrans.position.x;
        randPosY += spawnPlaneTrans.position.y;

        newObj.transform.position = new Vector3(randPosX, randPosY, spawnPlaneTrans.position.z);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }

}
