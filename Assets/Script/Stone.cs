using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class Stone : MonoBehaviour
    {

        internal void Die()
        {
            Destroy(this.gameObject);
        }
       
    }
}