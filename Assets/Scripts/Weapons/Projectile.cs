using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody bRigid;
    public float bSpeed = 8.5f;
	// Use this for initialization
	void Start ()
    {
        bRigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	public void Fire (Vector3 direction)
    {
        bRigid.AddForce(direction * bSpeed, ForceMode.Impulse);
        Destroy(gameObject, 2);
	}
}
