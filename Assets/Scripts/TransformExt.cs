using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public static class TransformExt
    {
        /*
        public static void LookAt2D(this Transform transform, Vector3 positionTarget)
        {
            var signedAngle = Vector2.SignedAngle(transform.up, (positionTarget - transform.position));

            if (Mathf.Abs(signedAngle) >= 1e-3f)
            {
                var angles = transform.eulerAngles;
                angles.z += signedAngle;
                transform.eulerAngles = angles;
            }
        }
        */
        public static void LookAt2D(this Transform transform, CheckAsteroid positionTarget)
        {
            var signedAngle = Vector2.SignedAngle(transform.up, (positionTarget.transform.position - transform.position));

            if (Mathf.Abs(signedAngle) >= 1e-3f)
            {
                var angles = transform.eulerAngles;
                angles.z += signedAngle;
                transform.eulerAngles = angles;
            }
        }
    }
}

