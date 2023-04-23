using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unknown.HelperTools.Extentions;

public class Ball : MonoBehaviour, IDamageable
{
    float health = 100f;
    float timer = 0;

    private void Update()
    {
        if(timer > 3f)
        {
            health += 10;
            Debug.Log("Objekt se zotavil: " + "+10".Colorful(Color.red));
        }
    }


    public void hit(float amount)
    {
        health -= amount;
        if(health < 0)
        {
            Debug.Log("Objekt zem�el:".Colorful(Color.red));
            Destroy(gameObject);
        }
        Debug.Log("Objekt byl zran�n: " + ("-" + amount.ToString()).Colorful(Color.red));
    }
}
