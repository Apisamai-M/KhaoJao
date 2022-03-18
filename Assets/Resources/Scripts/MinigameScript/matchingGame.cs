using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchingGame : MonoBehaviour
{
    [SerializeField]
    private Transform Place;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public static bool locked;
    public static int count = 0;
    new AudioSource audio;
    public AudioClip Correct;
    public AudioClip Wrong;

    void Start()
    {
        count = 0;
        initialPosition = transform.position;
        audio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!locked) {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (count != 4 && MatchingGameControl.GameOver != true) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
        
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - Place.position.x) <= 0.5f && Mathf.Abs(transform.position.y - Place.position.y) <= 0.5f) {
            transform.position = new Vector2(Place.position.x, Place.position.y);
            locked = true;
            count++;
            // Debug.Log(count);
            audio.clip = Correct;
            audio.Play();
            if(count == 4)
            {
                MatchingGameControl.instance.checkwin();
            }
        } else {
            if (count != 4 && MatchingGameControl.GameOver != true) {
                audio.clip = Wrong;
                audio.Play();
            }
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
