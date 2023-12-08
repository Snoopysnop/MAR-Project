using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
	public Camera camera;
	int zoom = 20;
    int normal = 60;
	float smooth = 5;
	bool isZoomed = false;
	GameObject shoulder;


	

	// Start is called before the first frame update
	void Start()
    {
		shoulder = GameObject.Find("Right_Shoulder");

	}

    // Update is called once per frame
  
	void LateUpdate()
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
			camera.transform.localPosition = (new Vector3(Mathf.Lerp(camera.transform.localPosition.x, 0.6f, Time.deltaTime * smooth), camera.transform.localPosition.y, camera.transform.localPosition.z));
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom, Time.deltaTime * smooth);
			shoulder.transform.Rotate(new Vector3(-50, 0, 0));
		}

		else
		{
			camera.transform.localPosition = (new Vector3(Mathf.Lerp(camera.transform.localPosition.x, 0, Time.deltaTime * smooth), camera.transform.localPosition.y, camera.transform.localPosition.z));
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normal, Time.deltaTime * smooth);


		}
	}

}