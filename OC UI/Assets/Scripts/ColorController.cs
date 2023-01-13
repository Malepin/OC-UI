using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorController : MonoBehaviour
{
    public GameObject R;
    public GameObject G;
    public GameObject B;
    public GameObject Avatar;
    private SkinnedMeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    public void Red()
    {
        Avatar.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        Debug.Log ("Red");
    }

    public void Green()
    {
        Avatar.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.green;
        Debug.Log("Green");
    }

    public void Blue()
    {
        Avatar.GetComponentInChildren<SkinnedMeshRenderer>().material.color= Color.blue;
        Debug.Log("Blue");
    }
}
