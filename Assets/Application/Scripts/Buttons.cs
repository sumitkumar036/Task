using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace VideoManagement
{
    enum ButtonType
    {
        Next,
        Previous,
        Forward,
        Backward
    }

    public class Buttons : MonoBehaviour
    {
        [SerializeField] private ButtonType _buttonType;
        private Button _button;

        private void Start()
        {
            if (_button == null)
             _button = GetComponent<Button>();

            _button.onClick.AddListener(delegate { OnButtonClick(_buttonType); });
                
        }


        /// <summary>
        /// This is to use the feature of video playeron selecting/clickinbg button
        /// </summary>
        /// <param name="buttonType"></param>
        private void OnButtonClick(ButtonType buttonType)
        {
           switch(buttonType)
            {
                case ButtonType.Next:
                    ApplicationManager._instance.videoPlayerManagement.Next();
                    break; 
                
                case ButtonType.Previous:
                    ApplicationManager._instance.videoPlayerManagement.Previous();
                    break;


                case ButtonType.Forward:
                    ApplicationManager._instance.videoPlayerManagement.Forward();
                    break;

                case ButtonType.Backward:
                    ApplicationManager._instance.videoPlayerManagement.Backward();
                    break;
            }
        }
    }
}
