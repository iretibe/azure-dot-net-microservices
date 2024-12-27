namespace EternalCareHospital.SharedKernel
{
    public class DomainEventDispatcher<T> where T : IDomainEvent
    {
        private List<Action<T>> _actions { get; } = new ();

        public void Subscribe(Action<T> action)
        {
            if (_actions.Exists(a => a.Method == action.Method))
            {
                return;
            }

            _actions.Add(action);
        }

        public void Publish(T args)
        {
            foreach (var action in _actions)
            {
                action.Invoke(args);
            }
        }
    }
}
