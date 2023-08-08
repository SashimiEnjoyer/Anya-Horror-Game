using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionRandomization : MonoBehaviour
{
    public List<GameObject> locations = new List<GameObject>();
    public GameObject currentLocation;
    public int rngCheck;
    private bool activated;

    void Awake()
    {
        activated = false;
        if (activated == false)
            LocationRandomization();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LocationRandomization()
    {
        int n = locations.Count;
        int rng = Random.Range(0, n - 1);
        activated = true; // once activated (awake), cannot active again unless forced invoke LocationRandomization()

        currentLocation = locations[rng];
        rngCheck = rng;
        SetLocation();
    }

    public void SetLocation()
    {
        if (currentLocation != null)
        {
            transform.SetPositionAndRotation(currentLocation.transform.position, currentLocation.transform.rotation);
        }
        if (currentLocation = null) Debug.Log("location invalid");
    }
}
