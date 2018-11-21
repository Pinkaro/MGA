using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTeamCollider : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.tag == "Team")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
