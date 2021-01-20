using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;

    public GameObject Cannonball;
    public Transform ShotPoint;

    public GameObject Explosion;
    private void Update()
    {
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VericalRotation = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + 
            new Vector3(0, HorizontalRotation * rotationSpeed, VericalRotation * rotationSpeed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            
            // Added explosion for added effect
            Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);

            // Shake the screen for added effect
            Screenshake.ShakeAmount = 5;
        }
    }


}
