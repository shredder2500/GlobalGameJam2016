using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GGJ.UI
{
    public class ProgressBar : MonoBehaviour
    {
        private float _scale;

        public float Value
        {
            get
            {
                return transform.localScale.x;
            }
            set
            {
                var scale = transform.localScale;
                scale.x = _scale * value;
                if(scale.x < 0)
                {
                    scale.x = 0;
                }
                transform.localScale = scale;
            }
        }

        private void Start()
        {
            _scale = transform.localScale.x;
        }
    }
}
