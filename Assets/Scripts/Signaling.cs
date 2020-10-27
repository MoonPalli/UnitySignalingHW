using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Coroutine _increase;
    private Coroutine _decrease;
    private WaitForSeconds _secondsToWaite = new WaitForSeconds(1f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _increase = StartCoroutine(IncreaseVolume(_decrease));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _decrease = StartCoroutine(DecreaseVolume(_increase));
    }

    private IEnumerator IncreaseVolume(Coroutine coroutineToStop)
    {
        if (coroutineToStop != null)
            StopCoroutine(coroutineToStop);

        while (_alarm.volume != 1f)
        {
            _alarm.volume += 0.2f;

            yield return _secondsToWaite;
        }
    }

    private IEnumerator DecreaseVolume(Coroutine coroutineToStop)
    {
        StopCoroutine(coroutineToStop);

        while (_alarm.volume != 0)
        {
            _alarm.volume -= 0.2f;

            yield return _secondsToWaite;
        }
    }
}