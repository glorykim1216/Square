using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject particleCircle;
    public AudioClip dieSound;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("square")) //.tag. CompareTag() "square")
        {
            GameManager.gameOver = true;
            StartCoroutine(SoundDie());
        }
        //Debug.Log("tag");
    }

    IEnumerator SoundDie()
    {
        particleCircle.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(dieSound);
        yield return new WaitForSeconds(1);
        particleCircle.SetActive(false);

    }
}
