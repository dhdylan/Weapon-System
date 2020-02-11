using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        IKillable killable = collision.gameObject.GetComponent<IKillable>();
        if (killable != null)
        {
            //killable.Shot();
        }
        Destroy(this.gameObject);
    }
}
