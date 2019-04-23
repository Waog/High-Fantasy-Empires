using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public void takeHit()
    {
        die();
    }

    private void die()
    {
        Transform targetIndicator = GetComponent<FollowTransform>().target.transform;
        targetIndicator.position = Vector3.zero;
        transform.position = targetIndicator.position;
    }
}
