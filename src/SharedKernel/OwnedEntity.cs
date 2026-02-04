namespace SharedKernel;

public abstract class OwnedEntity : Entity
{
    public Guid UserId { get; private set; }

    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
}
