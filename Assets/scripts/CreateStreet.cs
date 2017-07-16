using System.IO;
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

    private GameObject[] leftSideLane;
    private Vector3 rightPosition = new Vector3(19.5f, 0, 0);
    private GameObject[] rightSideLane;
    private Vector3 leftPosition = new Vector3(-19.5f, 0, 0);

    private float distanceThreshold;
    private int oldestSection;

    private GameObject player;

    private Random rnd = new Random();

	// Use this for initialization
	void Start ()
    {
        streetPrefabs = Resources.LoadAll("StreetPrefabs");

        streetSections = new GameObject[NumberOfVisibleStreetsSections];
        leftSideLane = new GameObject[NumberOfVisibleStreetsSections];
        rightSideLane = new GameObject[NumberOfVisibleStreetsSections];

        for (int i = 0; i < NumberOfVisibleStreetsSections; i++)
        {
            PlaceNewSection(i);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        oldestSection = 0;

        int sectionIndex = (oldestSection + 3) % streetSections.Length;
        distanceThreshold = streetSections[sectionIndex].transform.position.z;
    }

    void PlaceNewSection(int i)
    {
        // Create section
        int sectionIndex = Random.Range(0, streetPrefabs.Length);

        GameObject section = (GameObject)Instantiate(streetPrefabs[sectionIndex]);
        //GameObject section = (GameObject)Instantiate(streetPrefabs[2]);
        streetSections[i] = section;

        // Place section
        float distance = section.GetComponent<MeshCollider>().bounds.size.z / 2 - 0.001f;
        position.z += distance;
        section.transform.position = position;
        position.z += distance;


        // Left Sidelane
        sectionIndex = Random.Range(0, streetPrefabs.Length);
        section = (GameObject)Instantiate(streetPrefabs[sectionIndex]);
        leftSideLane[i] = section;

        leftPosition.z += distance;
        section.transform.position = leftPosition;
        leftPosition.z += distance;

        // Left Sidelane
        sectionIndex = Random.Range(0, streetPrefabs.Length);
        section = (GameObject)Instantiate(streetPrefabs[sectionIndex]);
        rightSideLane[i] = section;

        rightPosition.z += distance;
        section.transform.position = rightPosition;
        rightPosition.z += distance;
    }

    // Update is called once per frame
    void Update ()
    {
        if (player.transform.position.z > distanceThreshold)
        {
            // Mainlane
            Destroy(streetSections[oldestSection]);
            // Sidelane
            Destroy(leftSideLane[oldestSection]);
            Destroy(rightSideLane[oldestSection]);

            PlaceNewSection(oldestSection);

            oldestSection++;
            if (oldestSection == streetSections.Length)
            {
                oldestSection = 0;
            }

            int sectionIndex = (oldestSection + 3) % streetSections.Length;
            distanceThreshold = streetSections[sectionIndex].transform.position.z;
        }
    }
}