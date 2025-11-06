using System;
using System.Collections.Generic;

namespace Yueyn.Main.Entry
{
    public sealed class Entry
    {
        private readonly Dictionary<Type,IComponent> _components=new();

        public T GetComponent<T>() where T : IComponent
        {
            _components.TryGetValue(typeof(T), out IComponent component);
            return (T)component;
        }

        public void Register(IComponent component)
        {
            component.OnRegister();
            _components.Add(component.GetType(), component);
        }

        public void Unregister(IComponent component)
        {
            component.OnUnregister();
            _components.Remove(component.GetType());
        }
    }
}