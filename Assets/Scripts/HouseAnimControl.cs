using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAnimControl : MonoBehaviour
{
    [SerializeField] private Animator _targer;

    private bool _trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _targer.SetBool("Enter", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _targer.SetBool("Enter", false);
    }
}
