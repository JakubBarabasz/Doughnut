using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviour : MonoBehaviour
{
    public GameObject ring;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {

            yield return new WaitForSeconds(2);
            Destroy(ring);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        yield return null;
    }
    void Update()
    {
        Application.targetFrameRate = 60;
        Destroy(ring, 15);
    }
}
