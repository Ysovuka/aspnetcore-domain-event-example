using System;
using System.Collections.Generic;

namespace Example.DomainEvents
{
    public class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private List<Delegate> _actions;

        //Registers a callback for the given domain event
        public  void Register<T>(Action<T> callback)
            where T : IDomainEvent
        {
            if (_actions == null)
                _actions = new List<Delegate>();

            _actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public void ClearCallbacks()
        {
            _actions.Clear();
        }

        //Raises the given domain event
        public void Raise<T>(T args)
            where T: IDomainEvent
        {
            if (_actions != null)
            {
                foreach (var action in _actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}
