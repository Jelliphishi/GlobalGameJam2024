using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laughometer : MonoBehaviour
{
    // Start is called before the first frame update
    //public Gradient gradient;
    public Slider slider;
    public int currentLaughter;
   public void setLaughingness(int laughingness){
        slider.value = laughingness;
   }
}
