using UnityEngine;
using System.Collections;

public class deadTime : MonoBehaviour {

    float DeadTime;

	void Start()
    {
        DeadTime = 5f;
    }
	// Update is called once per frame
	void Update () {
	    if (DeadTime + Time.time < Time.time)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
