using System.Collections;
using UnityEngine;

public class Cat_1_animation : MonoBehaviour
{
    private Animator _animator;

    private IEnumerator Start()
    {
        _animator = GetComponent<Animator>();

        while (true)
        {
            float random = Random.Range(1f, 3f);
            yield return new WaitForSeconds(random);
            _animator.Rebind();
        }
    }
}