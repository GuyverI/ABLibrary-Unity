using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelView
{
    public class Model : Observer.Subject
    {

    }

    public abstract class View : MonoBehaviour, Observer.ISubscriber
    {
        public abstract void OnNotified(string eventId, Observer.EventParams eventParams);

        public void OnNotified(string eventId)
        {
            OnNotified(eventId, null);
        }

        public void SetParent(View parent)
        {
            _parent = parent;
        }

        protected View _parent = null;
    }
}
