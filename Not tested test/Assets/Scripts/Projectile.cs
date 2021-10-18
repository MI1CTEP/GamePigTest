using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HP>() != null)
        {
            other.GetComponent<HP>().hp -= damage;
            other.GetComponent<HP>().CheckHP();
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
