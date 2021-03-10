using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildScript : MonoBehaviour
{
    public static buildScript Instance;

    public GameObject turret1;
    public GameObject turret2;
    public int buildselected = 1;

    private void Start()
    {
        Instance = this;

        turretToBuild = turret1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            turretToBuild = turret1;
            buildselected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            turretToBuild = turret2;
            buildselected = 2;
        }
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
