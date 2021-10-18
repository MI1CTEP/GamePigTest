using System.Collections;
using UnityEngine;

public class Taran : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HP>().hp -= 50 * Time.deltaTime;
            other.GetComponent<HP>().CheckHP();
        }
    }
}
