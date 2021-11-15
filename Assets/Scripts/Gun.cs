using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform source;

    public void Fire()
    {
        if (Physics.Raycast(source.position, source.forward, out var hitInfo))
        {
            var target = hitInfo.transform.parent.gameObject;
            if (target.layer == 7)  // Enemy layer
                Destroy(target);
        }
    }
}
