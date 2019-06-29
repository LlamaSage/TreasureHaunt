using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GhostWallCollision : MonoBehaviour
{

    private void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("InnerWall");
        foreach(GameObject go in gos)
        {
            Physics.IgnoreCollision(go.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
        }
    }

    /*void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.name+ " AND " +this.gameObject.name);
        if (c.gameObject.tag == "InnerWall")
        {
            Physics.IgnoreCollision(c.collider, GetComponent<Collider>(), true);
            Debug.Log("TEST");
        }
    }*/


}
