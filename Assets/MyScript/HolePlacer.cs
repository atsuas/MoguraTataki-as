using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class HolePlacer : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;

    bool isGenerated = false;
    public GameObject holePrefab;
    public GameObject molePrefab;
    public TrackableType type;


    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    public void GenerateMoles(GameObject holes)
    {
        foreach (Transform t in holes.transform)
        {
            GameObject child = t.gameObject;
            if(child.tag == "Hole")
            {
                Vector3 pos = child.transform.position;
                Instantiate(molePrefab, pos, molePrefab.transform.rotation);
            }
        }
    }

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.All))
            {
                Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
                Instantiate(molePrefab, hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }
}