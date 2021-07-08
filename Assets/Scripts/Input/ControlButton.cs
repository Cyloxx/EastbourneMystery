using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EastBourne
{
    public class ControlButton : Button, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent<PointerEventData> OnContolButtonPointerDown;
        public UnityEvent<PointerEventData> OnContolButtonPointerUp;

        public override void OnPointerDown(PointerEventData eventData)
        {
            //Debug.Log($"pointer down for {gameObject.name}");
            OnContolButtonPointerDown?.Invoke(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            //Debug.Log($"pointer up for {gameObject.name}");
            OnContolButtonPointerUp?.Invoke(eventData);
        }

    }
}
