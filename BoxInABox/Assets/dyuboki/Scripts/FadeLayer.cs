using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeLayer : MonoBehaviour
{

    Image img;

    private void Awake(){
        img = transform.GetComponent<Image>();
        img.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }

    public IEnumerator ChangeAlphaOverTime(float newAlpha, float time)
    {
        var alpha = img.color.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            //change color as you want
            var newColor = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(alpha, newAlpha , t));
            img.color = newColor;
            yield return new WaitForSeconds(time);
        }
        img.color = new Color(1.0f, 1.0f, 1.0f, newAlpha);
    }}
