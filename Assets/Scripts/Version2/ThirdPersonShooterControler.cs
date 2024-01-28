using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonShooterControler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;


    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    public GameObject crosshair;
    private Animator animator;

    public GameObject bulletHole;
    public float distance = 30f;
    private void Awake()
    { 
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;


        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetsInputs.aim)
        {
            
            crosshair.SetActive(true);
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotationOnMove(false);
            animator.SetLayerWeight(1,Mathf.Lerp(animator.GetLayerWeight(1),1f,Time.deltaTime * 10f));


            Vector3 wordAimTarget = mouseWorldPosition;
            wordAimTarget.y = transform.position.y;
            Vector3 aimDirection = (wordAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            
        }
        else
        {
            crosshair.SetActive(false);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetRotationOnMove(true);
            thirdPersonController.SetSensitivity(normalSensitivity);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (starterAssetsInputs.shoot && starterAssetsInputs.aim)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;


        
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
            {
                GameObject bH = Instantiate(bulletHole, hit.point + new Vector3(0f, 0f, -.02f), Quaternion.LookRotation(-hit.normal));
                Destroy(bH, 1.0f);

            }
            

        }

    }
}
 