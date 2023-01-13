using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject Male;
    public GameObject Female;
    // Start is called before the first frame update
    void Start()
    {
        Male.SetActive(true);
        Female.SetActive(false);
    }

    // Update is called once per frame
    public void male()
    {
        Male.SetActive(true);
        Female.SetActive(false);
    }

    public void female()
    {
        Male.SetActive(false);
        Female.SetActive(true);
    }
}
