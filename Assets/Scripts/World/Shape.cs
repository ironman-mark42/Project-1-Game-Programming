using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public float speed = 1;
    [Range(0,30)]public float distortion = 1;
    public int score = 1;

    private bool isCount;
    private Vector2 direction;

    private void Start () {
        direction = -transform.position + Vector3.up;
        direction.x += Random.Range(-5f,5f);
    }

    private void Update () {
        if (Time.frameCount % Random.Range (8,32) == 0) direction.x += Distortion();
        transform.position = Vector2.MoveTowards (transform.position, direction, speed * Time.deltaTime);
    }

    private void OnMouseDown () {
        //Count();
    }

    public void Count () {
        isCount= true;
        Analytics.score += score;
        Remove();
    }

    private void Miss () {
        if (Analytics.attempts >= 1) Analytics.attempts--;
        Remove();
    }

    private void OnBecameInvisible () {
        if (!isCount) Miss();
    }

    private void Remove () {
        Destroy (gameObject);
    }

    private float Distortion () {
        return Random.Range(-distortion, distortion);
    }
}
