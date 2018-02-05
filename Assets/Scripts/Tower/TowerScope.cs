using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScope : MonoBehaviour {

    // Use this for initialization

    public System.Action<string, Enemy> someBodyDetected;
    public System.Action<string, Enemy> someBodyLeft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogFormat("OnTriggerEnter");
        someBodyDetected?.Invoke(other.tag, other.GetComponent<Enemy>());
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.LogFormat("OnTriggerEnter");
        someBodyLeft?.Invoke(other.tag, other.GetComponent<Enemy>());
    }
}
