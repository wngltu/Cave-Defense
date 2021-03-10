using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2Script : MonoBehaviour
{
    Transform target;

    public float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            onTargetHit();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    public void seekTarget(Transform seektarget)
    {
        target = seektarget;
    }

    void onTargetHit()
    {
        Destroy(gameObject);
    }
}
