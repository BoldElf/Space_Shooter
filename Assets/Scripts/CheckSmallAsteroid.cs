using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSmallAsteroid : MonoBehaviour
{
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
