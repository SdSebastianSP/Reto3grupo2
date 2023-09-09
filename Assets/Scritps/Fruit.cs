using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private ScoreManager scoreManager;
    private AudioSource sonido;
    private bool isCollected = false;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        sonido = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player"))
        {
            isCollected = true;
            sonido.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);

            scoreManager.SumScore();
        }
    }
}
