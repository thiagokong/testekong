using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[HelpURL("https://doc.clickup.com/9017157017/p/h/8cqdtct-30337/d473739efa49988")]
public class GroundButton : MonoBehaviour
{
    [Tooltip("The events will be played in order")]
    public EventWithDelay[] Events;

    [Header("Settings")]
    [SerializeField] private Image buttonFill;
    private void Awake()
    {
        Cancell();
    }
    public void Cancell()
    {
        buttonFill.fillAmount = 0;
        StopAllCoroutines();
    }

    public IEnumerator Fill(Transform player)
    {
        buttonFill.fillAmount = 0;

        while (buttonFill.fillAmount < 1)
        {
            buttonFill.fillAmount += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        player.transform.forward = transform.forward;
        buttonFill.fillAmount = 0;
        StartCoroutine(PlayEvents());
    }

    public IEnumerator PlayEvents()
    {
        foreach(EventWithDelay Event in Events)
        {
            yield return new WaitForSeconds(Event.Delay);
            Event.Events.Invoke();
        }
    }
}
[Serializable]
public class EventWithDelay
{
    public string Name =  "New Event";
    [Tooltip("Event delay in seconds")]
    public float Delay;
    public UnityEvent Events;
}
