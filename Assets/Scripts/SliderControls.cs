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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(plusButton))
        {
            slider.value += step;
        }
        else if (Input.GetKeyDown(minusButton))
        {
            slider.value -= step;
        }
    }
}
