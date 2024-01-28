using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laughometer : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public int maxLaughter = 100;
    public int currentLaughter;

    void Start(){
        currentLaughter = 50;
    }
   public void setLaughingness(int health){
        slider.value = health;
   }
}
