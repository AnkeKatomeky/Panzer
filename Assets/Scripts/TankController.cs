using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public ActorStats Stats;
    public CharacterController Controller;
    public WeaponControl Tower;
    public GameObject Camera;
    public GameObject EndScreen;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * Stats.SpeedRotation * Time.deltaTime, 0);
        Vector3 forward = transform.forward;
        float movSpeed = Input.GetAxis("Vertical") * Time.deltaTime * Stats.Speed;
        Controller.SimpleMove(movSpeed * forward);

        Tower.transform.rotation = Quaternion.Lerp(Tower.transform.rotation, Camera.transform.rotation, Time.deltaTime * Stats.TowerRotationSpeed);

        if (Input.GetKey(KeyCode.Q))
        {
            Tower.ChangeWeapon();
        }

        if (Input.GetKey(KeyCode.X))
        {
            Tower.Fire();
        }

        if (Stats.HP < 0)
        {
            EndScreen.SetActive(true);
        }
    }

    void LateUpdate()
    {
        Camera.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * Stats.SpeedRotation, 0);
        Camera.transform.position = transform.position;
    }
}
