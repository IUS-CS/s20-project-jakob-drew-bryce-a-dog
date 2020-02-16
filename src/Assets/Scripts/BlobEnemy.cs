using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEnemy : MonoBehaviour
{
    //public variables can be set to defaults here and then changed in inspector
    public bool HideOnDeath = true;
    public bool PhysicsOnDeath;
    public float respawnTime;

    private Vector3 upForceNudge;

    // Start is called before the first frame update
    void Start()
    {
        upForceNudge = new Vector3(0f, 0.1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when the capsule collider is hit by an arrow with enough force
    public void TakeDamageFromEvent()
    {
        // cancel any running coroutines on this gameObject just in case
        StopAllCoroutines();

        if (HideOnDeath)
        {
            // hide this gameObject's mesh when it is hit by an arrow
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            // turn it back on (primitive "respawn") some time seconds later
            StartCoroutine(DelayReenableMesh(respawnTime));
        }
        else if (PhysicsOnDeath)
        {
            // add a rigidbody (basic building block of Unity's physics engine) to this gameObject when it is hit by an arrow
            this.gameObject.AddComponent<Rigidbody>();
            // give it a nudge on the y-axis to let Unity know we want it to move now
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up);
        }
    }

    private IEnumerator DelayReenableMesh(float delay)
    {
        yield return new WaitForSeconds(delay);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
