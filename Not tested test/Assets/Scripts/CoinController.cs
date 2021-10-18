using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Transform _player;
    private Rigidbody _rigidbody;
    private bool _move;

    IEnumerator Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().isTrigger = true;
        _rigidbody.useGravity = false;
        _move = true;
    }
    private void Update()
    {
        if (_move)
        {
            transform.LookAt(_player.position);
            transform.Translate(Vector3.forward * Time.deltaTime * 25);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<QuantityOfCoins>().CoinPlus();
            Destroy(gameObject);
        }
    }
}
