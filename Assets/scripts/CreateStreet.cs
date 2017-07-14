using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStreet : MonoBehaviour
{
    [SerializeField]
    private int NumberOfVisibleStreetsSections = 2;

    private Object[] streetPrefabs;
    private GameObject[] streetSections;
    private Vector3 distance = new Vector3(0, 0, 10);
    private Vector3 position = new Vector3(0, 0, 0);
    private int oldestCreatedSection = 0;

    private Random rnd = new Random();

	// Use this for initialization
	void Start ()
    {
        streetPrefabs = Resources.LoadAll("Prefabs");
        streetSections = new GameObject[NumberOfVisibleStreetsSections];

        for (int i = 0; i < NumberOfVisibleStreetsSections; i++)
        {
            PlaceNewSection(i);
        }
    }

    void PlaceNewSection(int positionInArray)
    {
        // Create section
        int j = Random.Range(0, streetPrefabs.Length);

        GameObject section = (GameObject)Instantiate(streetPrefabs[j]);
        streetSections[positionInArray] = section;

        // Place section
        position.z += section.GetComponent<MeshCollider>().bounds.size.z / 2;
        section.transform.position = position;
        position.z += section.GetComponent<MeshCollider>().bounds.size.z / 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Player is behind second street section
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Destroy(streetSections[oldestCreatedSection]);
            PlaceNewSection(oldestCreatedSection);

            oldestCreatedSection++;
            if (oldestCreatedSection == streetSections.Length)
            {
                oldestCreatedSection = 0;
            }
        }
	}
}
