using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Joystick joystick;
    public GameObject ring;
    public TextMeshProUGUI ringAmount;
    public int ringAmountInt;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootRing();
        }
        ringAmount.text = ringAmountInt.ToString();
    }
    public void ShootRing()
    {
        if (ringAmountInt > 0)
        {
            ringAmountInt--;
            GameObject newRing = Instantiate(ring, transform.position, transform.rotation);
            newRing.transform.rotation = Quaternion.Euler(90, 0, 0);
            newRing.GetComponent<Rigidbody>().AddForce(transform.forward * -joystick.Horizontal * 500);
            newRing.GetComponent<Rigidbody>().AddForce(-transform.right * -joystick.Vertical * 1500);
            ringAmount.text = ringAmountInt.ToString();
        }
        else
        {
            ringAmount.text = "No rings";
        }

    }
}
