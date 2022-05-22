using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public Joystick joystick;
    public Image joystickHandle;
    public Image joystickRing;
    public GameObject ring;
    public int ringAmountInt;
    private Color myColor;
    public float joystickDistance;

    public void Start()
    {
    }
    void Update()
    {
        ringAmountInt = PlayerPrefs.GetInt("rings");

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootRing();
        }
        
        if (joystick.Vertical > 0)
           joystickDistance = joystick.Vertical;
        
        else
            joystickDistance = -joystick.Vertical;
       
        
        myColor = new Color(2.0f * joystickDistance, 2.0f * (1 - joystickDistance), 0);
        joystickHandle.color = myColor;
        joystickRing.color = myColor;
    }
    public void ShootRing()
    {
        if (ringAmountInt > 0)
        {
            ringAmountInt = PlayerPrefs.GetInt("rings");
            ringAmountInt--;
            PlayerPrefs.SetInt("rings", ringAmountInt);
            GameObject newRing = Instantiate(ring, transform.position, transform.rotation);
            newRing.transform.rotation = Quaternion.Euler(90, 0, 0);
            newRing.GetComponent<Rigidbody>().AddForce(transform.forward * -joystick.Horizontal * 500);
            newRing.GetComponent<Rigidbody>().AddForce(-transform.right * -joystick.Vertical * 1500);
        }
    }
}
