using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhy : MonoBehaviour
{

    public GameObject obj1;
    public GameObject obj2;

    void Update()
    {

        RaycastHit hit;
        if (Physics.Linecast(obj1.transform.position, obj2.transform.position, out hit, 1<<LayerMask.NameToLayer("Ground")))
        {
            Debug.Log(111);
            Debug.Log(hit.transform.gameObject.name);
        }
    }
}
