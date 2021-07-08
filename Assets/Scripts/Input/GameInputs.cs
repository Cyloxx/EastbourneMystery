using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EastBourne
{
    public class GameInputs : MonoBehaviour
    {
        [SerializeField] public Platform platform;
        private PlatformInputs platformInputs;
        public GameObject MobileUIPanel;

        public bool GetJump()
        {
            return platformInputs.GetJump();
        }

        public bool GetAttack()
        {
            return platformInputs.GetAttack();
        }

        public float GetMove()
        {
            return platformInputs.GetMove();
        }

        private void Start()
        {
            //TODO add other platforms
            if (platform == Platform.Mobile)
                MobileUIPanel.SetActive(true);
            else
                MobileUIPanel.SetActive(false);


            switch (platform)
            {
                case Platform.PC:
                    platformInputs = gameObject.GetComponent<PcInputs>();
                    break;
                case Platform.Mobile:
                    platformInputs = gameObject.GetComponent<MobileInputs>();

                    break;
                case Platform.PS:
                    break;
                case Platform.Switch:
                    break;
                case Platform.XBOX:
                    break;
                default:
                    break;
            }
        }
    }

    public enum Platform
    {
        PC,
        Mobile,
        PS,
        Switch,
        XBOX
    } 
}