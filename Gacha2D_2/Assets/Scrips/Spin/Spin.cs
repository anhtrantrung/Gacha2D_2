using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public static Spin instance;
    public TextMeshPro item;
    public TextMeshPro itemUI;
    public Transform ring;

    public float speed = 0f;
    public float maxSpeed ;
    public float slowDown;
    public float randomStop;
    public string nameItem;
    public string stopAt;
    
    public bool stop = false;
    public bool spinning= false;

    void Awake()
    {
        Spin.instance = this;
       
    }

    private void OnMouseDown()
    {
        stopAt = ShowItem.instance.RandomIten();
        StarSpin();
        Invoke("RandomStop", randomStop = Random.Range(3, 5));
    }

    private void FixedUpdate()
    {
        Spinning();
        Stop();
    }

    public void StarSpin()
    {
        spinning = true;
        stop = false;
        speed = maxSpeed;
    }    

    public void Spinning()
    {
        ring.Rotate(0, 0, Time.deltaTime * speed);
        Stop();
    }

    public void ExportItem(TextMeshPro txt)
    {
        if(speed == 0 && stop == true)
        {
            itemUI.text ="Item: "+ txt.text;
        }    
    }

    public void RandomStop()
    {
        stop= true;
    }

    public void Stop()
    {
        if (!stop)
        {
            return;
        }

        if (stopAt == SpinnerMarker.instance.itenName)
        {
            spinning = false;
        }

        if (spinning)
        {
            return;
        }

        speed -= slowDown;
        if (speed < 0)
        {
            speed = 0;
        }
    }
}
