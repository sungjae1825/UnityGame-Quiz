using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{

    public GameObject Choice;

    public void OptionDown()
    {
        Choice.SetActive(true);
    }
}