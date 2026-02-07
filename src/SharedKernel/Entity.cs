namespace SharedKernel;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsInactive { get; private set; }
    public int? IdTmp { get; set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    public List<IDomainEvent> DomainEvents => [.. _domainEvents];

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void Init(DateTime date)
    {
        Id = Guid.CreateVersion7();
        CreatedAt = date;
        IsDeleted = false;
        IsInactive = false;
    }
    public void Touch(DateTime date)
    {
        UpdatedAt = date;
    }
    public void MarkAsDeleted(DateTime date)
    {
        IsDeleted = true;
        DeletedAt = date;
    }

    public void MarkAsInactive()
    {
        IsInactive = true;
    }

    public void MarkAsActive(DateTime date)
    {
        IsInactive = false;
        UpdatedAt = date;
    }
}
