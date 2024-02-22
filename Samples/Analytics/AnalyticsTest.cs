using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServicesToolkit.Utils.GoogleServicesUtils;

public class AnalyticsTest : MonoBehaviour
{
    [SerializeField] private GameObject testObject;
    private GameObject nonSerializeTestObject;
    
    // Start is called before the first frame update
    void Start()
    {
        if (testObject.NullCheckAndLog("Test"))
        {
            Debug.Log("testObject is not null");
        }
        if (nonSerializeTestObject.NullCheckAndLog("Test"))
        {
            Debug.Log("nonSerializeTestObject is not null");
        }
    }
}
