using UnityEngine;

public class ThrowIntoBin : MonoBehaviour
{
    public Vector3 respawnPoint;
    private Rigidbody rb;

    void Start()
    {
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // This method will be called when the object collides with something
    void OnCollisionEnter(Collision collision)
    {
        print("Can collided with " + collision);
        if (collision.gameObject.CompareTag("Bin"))
        {
            collision.gameObject.GetComponent<BinScript>().OnObjectEntered(true);
            gameObject.SetActive(false); 
            print("Can is in bin");
        }
        else
        {
            Invoke("Respawn", 1f);
        }
    }

    // Respawn the object at the starting point
    void Respawn()
    {
        transform.position = respawnPoint;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(true);
    }
}