using UnityEngine;
using UnityEngine.UI;

public class ImageCarousel : MonoBehaviour
{
    public Sprite[] sprites;
    public Image img;
    public GameObject controls;

    private int index = 0;
    private GameObject next;
    private GameObject previous;

    public void Awake()
    {
        // get next and previous buttons
        next = controls.transform.GetChild(0).gameObject;
        previous = controls.transform.GetChild(1).gameObject;
    }

    public void Update()
    {
        // check sprite array for current position and manage possible circumstances
        if (index >= sprites.Length)
        {
            index = sprites.Length-1;
            next.SetActive(false);
        }else if(index < 0)
        {
            previous.SetActive(false);
            index = 0;
        }
        else
        {
            if (next.activeSelf == false)
            {
                next.SetActive(true);
            }

            if (previous.activeSelf == false)
            {
                previous.SetActive(true);
            }
          
            img.sprite = sprites[index];
        }

        // hide/unhide controls
        if (sprites.Length <= 1)
        {
            controls.SetActive(false);
        }
        else
        {
            controls.SetActive(true);
        }
    }

    // resets the ImageCarousel to the first image
    public void Reset()
    {
        index = 0;
    }

    // skips to the next image
    public void Next()
    {
        index++;
    }

    // skips to the previous image
    public void Previous()
    {
        index--;
    }

    // fill ImageCarousel with an array of sprites
    public void FillCarousel(Sprite[] _sprites)
    {
        sprites = _sprites;
    }
}