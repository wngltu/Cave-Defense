using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSpots : MonoBehaviour
{
    public Vector3 positionOffset;
    GameObject turret;
    public GameObject space;
    public bool occupied;
    public static buildSpots Instance;

    private void Start()
    {
        Instance = this;
    }

    private void OnMouseDown()
    {
        if (!occupied && playerController.Instance.currentEnergy >= 50 && buildScript.Instance.buildselected == 1)
        {
            GameObject turret = buildScript.Instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turret, transform.position + positionOffset, transform.rotation);
            playerController.Instance.currentEnergy -= 50;
            occupied = true;
            Invoke("unoccupy", 45f);
        }
        if (!occupied && playerController.Instance.currentEnergy >= 100 && buildScript.Instance.buildselected == 2)
        {
            GameObject turret = buildScript.Instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turret, transform.position + positionOffset, transform.rotation);
            playerController.Instance.currentEnergy -= 100;
            occupied = true;
            Invoke("unoccupy", 60f);
        }
    }

    void unoccupy()
    {
        occupied = false;
    }
}
