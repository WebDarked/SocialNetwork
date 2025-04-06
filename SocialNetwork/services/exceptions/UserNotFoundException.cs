namespace SocialNetwork.services.exceptions;

public class UserNotFoundException(string requestEmail) : Exception($"User with email {requestEmail} not found.");