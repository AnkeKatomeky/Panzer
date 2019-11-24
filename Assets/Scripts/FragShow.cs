using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragShow : MonoBehaviour
{
    public ActorStats PlayerStats;
    public Text Show;
    // Update is called once per frame
    void Update()
    {
        Show.text = PlayerStats.Frags.ToString();
    }
}
