using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] limbs;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 sum = Vector3.zero;
        int numOfIdle = 0;
        int numOfDragged = 0;

        foreach (GameObject limb in limbs)
        {
            sum += limb.transform.position;
           if (limb.GetComponent<Hand>().GetIdle()) { numOfIdle++; }
           if (limb.GetComponent<Hand>().GetDragged()) { numOfDragged++; }
        }

        if (numOfIdle + numOfDragged == limbs.Length) 
        {
            transform.position -= new Vector3(0, 0.0981f);
        }
        else
        {
            transform.position = sum / limbs.Length;
        }

        
    }
}
