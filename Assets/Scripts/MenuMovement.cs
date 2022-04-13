using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening; 

public class MenuMovement : MonoBehaviour
{
    private bool menuOut; // flag (btn behaves differetly depending on menu position) 
    Transform menuTransform;

    float glide = 160; // moving across the screen from starting position
    float glideTime = 1;
    float hide = 25; // moving out of the screen 
    float hideTime = 0.2f; 
    float flipTime = 0.2f; 
    void Start()
    {
        menuOut = true;
        menuTransform = GameObject.FindWithTag("menu").GetComponent<Transform>();
    }

    public void ButtonPressed()
    {
        Sequence sequence = DOTween.Sequence(); 
       if(menuOut == true)
        {
            // 1. move the menu and the btn same distance from their starting position 
            // 2. move the menu even further (hide from the screen)
            // 3. reverse arrow direction 
            sequence.Append(menuTransform.DOMoveX(menuTransform.position.x - glide, glideTime)).Join(transform.DOMoveX(transform.position.x - glide, glideTime))
                .Append(menuTransform.DOMoveX(menuTransform.position.x - glide - hide, hideTime)).Append(transform.DOScale(-1, flipTime)); 

            menuOut = false; 
        }
        else
        {
            // 1. unhide menu
            // 2. glide back (menu + btn) 
            // 3. reverse arrow direction 
            sequence.Append(menuTransform.DOMoveX(menuTransform.position.x + hide, hideTime))
                .Append(menuTransform.DOMoveX(menuTransform.position.x + hide + glide, glideTime))
                .Join(transform.DOMoveX(transform.position.x + glide, glideTime))
                .Append(transform.DOScaleX(1, flipTime)); 

            menuOut = true; 
        }

    }
}
