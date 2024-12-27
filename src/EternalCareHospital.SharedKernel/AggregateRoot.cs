namespace EternalCareHospital.SharedKernel
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _events = new ();

        public int Version { get; private set; }

        public IReadOnlyCollection<IDomainEvent> GetChanges()
        {
            return _events.AsReadOnly();
        }

        public void ClearChanges()
        {
            _events.Clear();
        }

        protected void ApplyDomainEVent(IDomainEvent domainEvent)
        {
            ChangeStateByUsingDomainEvent(domainEvent);

            _events.Add(domainEvent);
            Version++;
        }

        public void Load(IEnumerable<IDomainEvent> events)
        {
            foreach (var e in events)
            {
                ApplyDomainEVent(e);
            }

            ClearChanges();
        }

        protected abstract void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent);
    }
}
