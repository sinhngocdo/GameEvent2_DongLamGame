using System;

namespace Ngocsinh.Observer
{
    public abstract class Subject
    {
        private Action _event;


        public virtual void AddListener(IObserver observer)
        {
            _event += observer.OnNotify;
        }

        public virtual void RemoveListener(IObserver observer)
        {
            _event -= observer.OnNotify;
        }

        public virtual void UpdateEvent()
        {
            _event?.Invoke();
        }
        
    }
}
