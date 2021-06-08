using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class BestResult : MonoBehaviour
    {
        [SerializeField]
        public Text input;

        [SerializeField] private float Monets;
        private void Start()
        {
            Monets = PlayerPrefs.GetFloat("MonetsPlayerEnemy");
            if (Monets >= 0 || Monets < 0)
            {
                if (PlayerPrefs.HasKey("MonetsPlayerEnemy"))
                {
                    input.text = " " + PlayerPrefs.GetFloat("MonetsPlayer") + "/" + PlayerPrefs.GetFloat("MonetsEnemy");

                }
                else
                {
                    input.text = " " + 0;
                }
            }
            else {
                PlayerPrefs.SetFloat("MonetsPlayerEnemy",0);

         }
        }

        private void Update()
        {

            if (PlayerPrefs.HasKey("MonetsPlayerEnemy"))
            {
                input.text = " " + PlayerPrefs.GetInt("MonetsPlayer") + "/" + PlayerPrefs.GetFloat("MonetsEnemy");

            }
            else
            {
                input.text = " " + 0;
            }
        }

    }
}