using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodPlus : MonoBehaviour
{
    public GameObject canvas;
    public int x,y;
    public float timer;
    public int speed;
    public float fadeDuration = 1f;
    private float fadeTimer = 0f;
    private CanvasGroup canvasGroup;

    void Start()
    {
        timer = 0;
        canvas = GameObject.Find("Canvas");
        transform.SetParent(canvas.transform);
        x = Random.Range(-640, -250);
        y = Random.Range(-200, 152);

        //Code Youtube Video
        // x = Random.Range(-150, 151);
        // y = Random.Range(-150, 151);

        transform.localPosition = new Vector3(x, y,0);

        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update() 
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            Destroy(this.gameObject);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, 0);

        Fade();
    }
    private void Fade()
    {
        fadeTimer += Time.deltaTime;

        if (fadeTimer <= fadeDuration)
        {
            float t  = fadeTimer/fadeDuration;
            float alpha = Mathf.Lerp(0.9f, 0f, t);

            canvasGroup.alpha = alpha;
        }
    }
}
