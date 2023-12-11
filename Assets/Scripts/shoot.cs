using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shoot : MonoBehaviour
{
	public Camera camera;
	int zoom = 20;
    int normal = 60;
	float smooth = 5;
	bool isZoomed = false;
	// GameObject shoulder;

	public GameObject crosshair;

	[SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
	[SerializeField] private Transform debugTransform;



	// Start is called before the first frame update
	void Start()
    {
		// shoulder = GameObject.Find("Right_Shoulder");
		crosshair.SetActive(false);
	}

    // Update is called once per frame
  
	void LateUpdate()
    {
		/*Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
		Ray ray = camera.ScreenPointToRay(screenCenterPoint);
		if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
		{
			debugTransform.position = raycastHit.point;
		}*/

		if (Input.GetMouseButtonDown(1))
        {
			isZoomed = true;
			crosshair.SetActive(true);
		}
        if (Input.GetMouseButtonUp(1))
        {
			isZoomed = false;
			crosshair.SetActive(false);
		}

		if (isZoomed == true)
		{
			camera.transform.localPosition = (new Vector3(Mathf.Lerp(camera.transform.localPosition.x, 0.6f, Time.deltaTime * smooth), camera.transform.localPosition.y, camera.transform.localPosition.z));
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom, Time.deltaTime * smooth);
			// shoulder.transform.Rotate(new Vector3(-50, 0, 0));

			/*Vector3 worldAimTarget = mouseWorldPosition;
			worldAimTarget.y = debugTransform.position.y;
			Vector3 aimDirection = (worldAimTarget - debugTransform.position).normalized;

			transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);*/
		}

		else
		{
			camera.transform.localPosition = (new Vector3(Mathf.Lerp(camera.transform.localPosition.x, 0, Time.deltaTime * smooth), camera.transform.localPosition.y, camera.transform.localPosition.z));
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normal, Time.deltaTime * smooth);
		}
	}

}