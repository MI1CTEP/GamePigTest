using System;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float _speed;
    private Transform _playerPosition;

    private float _distance = 10f;

    private void Start()
    {
        _playerPosition = FindObjectOfType<PigController>().GetComponent<Transform>();
    }

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
        _distance -= _speed * Time.deltaTime;

        if (_distance <= 0)
        {
            float playerPosition = Vector3.Distance(transform.position, _playerPosition.position);
            if (playerPosition > 4f)
                RandomRotate(true);
            else
                MoveToPlayer();
            _distance = 2.5f;
        }
    }
    private void MoveToPlayer()
    {
        float distanceX = transform.position.x - _playerPosition.position.x;
        float distanceZ = transform.position.z - _playerPosition.position.z;

        if (Math.Abs(distanceX) > Math.Abs(distanceZ))
        {
            if (distanceX < 0)
                transform.rotation = Quaternion.Euler(0, 90, 0);
            else
                transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            if (distanceZ > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void RandomRotate(bool rotate)
    {
        while (rotate)
        {
            int rotationAngle = UnityEngine.Random.Range(0, 4);
            switch (rotationAngle)
            {
                case 0:
                    transform.Rotate(0, 90, 0);
                    break;
                case 1:
                    transform.Rotate(0, -90, 0);
                    break;
                case 2:
                    transform.Rotate(0, 180, 0);
                    break;
                case 3:
                    break;
            }
            Ray ray = new Ray(new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.distance > 1f || hit.transform.GetComponent<DetonationBomb>() != null)
                    rotate = false;
        }
    }
}
