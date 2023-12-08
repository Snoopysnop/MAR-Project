using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
	public Camera target;
	int zoom = 20;
    int normal = 60;
	float smooth = 5;
	bool isZoomed = false;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
			isZoomed = true;

		}
        if (Input.GetMouseButtonUp(1))
        {
			isZoomed = false;

		}
			
		
		if (isZoomed == true)
		{
			target.fieldOfView = Mathf.Lerp(target.fieldOfView, zoom, Time.deltaTime * smooth);
		}

		else
		{
			target.fieldOfView = Mathf.Lerp(target.fieldOfView, normal, Time.deltaTime * smooth);
		}

			
	}

    void OnBouloute()
    {

    }
}
