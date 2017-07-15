using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStreet : MonoBehaviour
{
    [SerializeField]
    private int NumberOfVisibleStreetsSections = 2;

    private Object[] streetPrefabs;
    private GameObject[] streetSections;
    private Vector3 position = new Vector3(0, 0, 0);
    private float distanceThreshold;
    private int oldestSection;

    private GameObject player;

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

        player = GameObject.FindGameObjectWithTag("Player");
        oldestSection = 0;

        int sectionIndex = (oldestSection + 2) % streetSections.Length;
        distanceThreshold = streetSections[sectionIndex].transform.position.z;
    }

    void PlaceNewSection(int i)
    {
        // Create section
        int sectionIndex = Random.Range(0, streetPrefabs.Length);

        //GameObject section = (GameObject)Instantiate(streetPrefabs[sectionIndex]);
        GameObject section = (GameObject)Instantiate(streetPrefabs[1]);
        streetSections[i] = section;

        // Place section
        position.z += section.GetComponent<MeshCollider>().bounds.size.z / 2;
        section.transform.position = position;
        position.z += section.GetComponent<MeshCollider>().bounds.size.z / 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.z > distanceThreshold)
        {
            Destroy(streetSections[oldestSection]);
            PlaceNewSection(oldestSection);

            oldestSection++;
            if (oldestSection == streetSections.Length)
            {
                oldestSection = 0;
            }

            int sectionIndex = (oldestSection + 2) % streetSections.Length;
            distanceThreshold = streetSections[sectionIndex].transform.position.z;
        }
    }
}
