using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlatform : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platformPrefabs;

    private List<GameObject> platforms;

    private Transform ballTransform;

	// Use this for initialization
	void Start ()
    {
        platforms = new List<GameObject>();

        GameObject tempPref = Instantiate(platformPrefabs[0]);
        tempPref.transform.position = new Vector3(0, 0, 0);
        tempPref.transform.SetParent(transform);
        platforms.Add(tempPref);

        GameObject tempPref2 = Instantiate(platformPrefabs[0]);
        tempPref2.transform.position = new Vector3(0, 0, 20);
        tempPref2.transform.SetParent(transform);
        platforms.Add(tempPref2);

        GameObject tempPref3 = Instantiate(platformPrefabs[0]);
        tempPref3.transform.position = new Vector3(0, 0, 40);
        tempPref3.transform.SetParent(transform);
        platforms.Add(tempPref3);

        ballTransform = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (ballTransform.position.z >= platforms[1].transform.position.z + 10)
        {
            int index = Random.Range(0, platformPrefabs.Count);
            GameObject tempPref = platforms[0];
            platforms.RemoveAt(0);
            Destroy(tempPref);
            tempPref = Instantiate(platformPrefabs[index]);
            tempPref.transform.position = new Vector3(0, 0, platforms[1].transform.position.z + 20);
            tempPref.transform.SetParent(transform);
            platforms.Add(tempPref);
        }
	}
}
