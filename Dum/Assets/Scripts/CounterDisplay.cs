using UnityEngine;
using UnityEngine.UI;

public class CounterDisplay : MonoBehaviour
{
    public Text counter;
    //public int counterText = KillCounter.killCount;

    // Update is called once per frame
    void Update()
    {
        counter.text = KillCounter.killCount.ToString();
    }
}
