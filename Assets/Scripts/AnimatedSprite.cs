using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] 
    private List<Sprite> animationFrames;

    [SerializeField][Range(1.01f, 10.0f)] 
    private float animationSpeed = 1f;

    private Image image;
    private float timer = 0f;
    private int i = 1; // set to 1 since the first frame is the base image
    private bool animationIsOn = false;

    private void Start()
    {
        image = GetComponent<Image>();
        gameObject.SetActive(false);
        image.sprite = animationFrames[0];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f / animationSpeed && animationIsOn)
        {
            timer = 0f;
            image.sprite = animationFrames[i];
            i = (i + 1) % animationFrames.Count;
        }
    }

    public void PlayAnimation()
    {
        animationIsOn = true;
    }

    public void PauseAnimation()
    {
        animationIsOn = false;
    }
}