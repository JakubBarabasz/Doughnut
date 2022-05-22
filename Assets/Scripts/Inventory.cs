using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;



public class Inventory : MonoBehaviour
{
    public Text ringsAmount;
    public int rings;
    public int maxRings = 15;
    public void Start()
    {
        maxRings = 15;
        StartCoroutine(AddRings(1));
    }
    private void Update()
    {
        rings = PlayerPrefs.GetInt("rings");
        ringsAmount.text = "Rings: " + rings.ToString();

        if (rings >= maxRings)
        {
            rings = maxRings;
            SendFullRingsMessage();
        }
    }

    public IEnumerator AddRings(int amount)
    {
        yield return new WaitForSeconds(5);
        if (rings < maxRings)
        {
            rings += amount;
            PlayerPrefs.SetInt("rings", rings);
            StartCoroutine(AddRings(1));
        }
    }

    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            StartCoroutine(AddRings(1));
        }
    }

    public void SendFullRingsMessage()
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = "example_channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic Notifications",

        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Rings refield!";
        notification.Text = "We hope you enjoy the game!";
        notification.SmallIcon = "icon_1";
        notification.LargeIcon = "icon_2";
        notification.ShowTimestamp = true;
        notification.FireTime = System.DateTime.Now.AddSeconds(5);

        var identifier =
            AndroidNotificationCenter.SendNotification(notification, "example_channel_id");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "example_channel_id");

        }
    }
}
