using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControls : MonoBehaviour
{
    PlayerBehaviour player;
    Slider slider;
    [SerializeField] KeyCode plusButton;
    [SerializeField] KeyCode minusButton;
    [SerializeField] float step;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        player = GameObject.FindObjectOfType<PlayerBehaviour>();
        slider.onValueChanged.Invoke(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(plusButton))
        {
            slider.value += step;
        }
        else if (Input.GetKey(minusButton))
        {
            slider.value -= step;
        }
    }
}
