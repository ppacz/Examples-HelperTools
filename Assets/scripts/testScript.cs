using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unknown.HelperTools.Extentions;

public class testScript : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("hittable"))
                {
                    hit.transform.GetComponent<IDamageable>().hit(10);
                    Debug.Log("Koule byla zasažena".Colorful(Color.green));
                }
                else
                {
                    Debug.Log("Minul jsi".Colorful(Color.yellow));
                }
            }
            else
            {
                Debug.Log("Minul jsi".Colorful(Color.yellow));
            }
        }
    }
}
