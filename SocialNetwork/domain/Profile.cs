namespace SocialNetwork.domain;

public class Profile : IEntity
{
    public Guid Id { get; set; }

    public User User { get; set; }
}