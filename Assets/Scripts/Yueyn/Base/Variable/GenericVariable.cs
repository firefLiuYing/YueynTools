using System;

namespace Yueyn.Base.Variable
{
    public abstract class Variable<T> : Variable
    {
        public override Type Type=>typeof(T);

        public T Value { get; set; } = default(T);
        public override object GetValue()=>Value;
        public override void SetValue(object value)=>Value = (T)value;
        public override void Clear()=>Value=default(T);
    }
}