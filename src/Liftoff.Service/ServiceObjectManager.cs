using System;

namespace Liftoff.Service
{
    public interface IManageServiceObjects
    {
        object BuildServiceObject();
        void Start(object serviceObject);
        void Stop(object serviceObject);
    }

    public class ServiceObjectManager<T> : IManageServiceObjects
    {
        public Func<T> Constructor { get; set; }
        public Action<T> StartAction { get; set; }
        public Action<T> StopAction { get; set; }

        public object BuildServiceObject()
        {
            return Constructor();
        }

        public void Start(object serviceObject)
        {
            StartAction((T)serviceObject);
        }

        public void Stop(object serviceObject)
        {
            StopAction((T)serviceObject);
        }
    }
}