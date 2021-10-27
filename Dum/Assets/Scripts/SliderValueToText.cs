using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
  Text sliderValue;

  void Start()
  {
    sliderValue = GetComponent<Text> ();
  }

  public void textUpdate(float value)
  {
    sliderValue.text = value.ToString();
  }
}