using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;
    public float speed = 40f;
    public float maxSpeed = 100f;
    public float minSpeed = 1f;
    public float accel = 3f;
    public float decel = 0.1f;
    void Start()
    {

    }


    void Update()
    {
        //updates player position by moving forward (25f speed) affected by Time.Deltatime
        transform.position += transform.forward * Time.deltaTime * speed;
        //Rotates player during flight

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeight > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = accel + Mathf.Clamp(speed, minSpeed, maxSpeed - accel);
        }
        else
        {
            speed = -decel + Mathf.Clamp(speed, minSpeed + accel, maxSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = -accel + Mathf.Clamp(speed, minSpeed +accel, maxSpeed);
        }


    }
    void Shoot()
    {
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        Projectile newProjectile = clone.GetComponent<Projectile>();
        newProjectile.Fire(transform.forward);
    }
}
