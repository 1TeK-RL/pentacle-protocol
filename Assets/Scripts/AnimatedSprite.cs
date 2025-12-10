using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedSprite : MonoBehaviour
{
    [SerializeField]
    private AnimationFrames currentAnimationFrames;

    [SerializeField]
    private string nameOfAnimation;

    [SerializeField]
    private bool playOnStart = false;



    private SpriteRenderer spriteRenderer;
    private Image spriteImage;
    private bool isSprite = true;
    private float timer = 0f;
    private int i = 1; // set to 1 since the first frame is the base image
    private bool animationIsOn = false;

    private void Start()
    {
        try
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            gameObject.SetActive(false);
            spriteRenderer.sprite = currentAnimationFrames.framesList[0];
            if (playOnStart)
            {
                PlayAnimation();
            }
            isSprite = true;
        }
        catch
        {
            Debug.Log("No Sprite found, looking for image.");
            spriteImage = GetComponent<Image>();
            gameObject.SetActive(false);
            spriteImage.sprite = currentAnimationFrames.framesList[0];
            if (playOnStart)
            {
                PlayAnimation();
            }
            isSprite = false;

        }


    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f / currentAnimationFrames.animationSpeed && animationIsOn)
        {
            timer = 0f;
            if (isSprite)
                spriteRenderer.sprite = currentAnimationFrames.framesList[i];
            else
                spriteImage.sprite = currentAnimationFrames.framesList[i];
            i = (i + 1) % currentAnimationFrames.framesList.Count;
        }
    }

    private void OnEnable()
    {
        EventManager.Instance.OnChangeAnimationType += SetAnimationType;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnChangeAnimationType -= SetAnimationType;
    }

    public void PlayAnimation()
    {
        gameObject.SetActive(true);
        animationIsOn = true;
    }

    public void PauseAnimation()
    {
        animationIsOn = false;
    }

    public void SetAnimationType(AnimationFrames newAnimationFrames)
    {
        if (nameOfAnimation == newAnimationFrames.animationName)
        {
            currentAnimationFrames = newAnimationFrames;
            i = 0;
        }
    }
}