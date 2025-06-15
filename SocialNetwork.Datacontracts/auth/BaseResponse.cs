using SocialNetwork.Datacontracts.@base;

namespace SocialNetwork.DataContracts.auth;

public record LoginResponse(string? Token = null, string? Error = null) : IResponse;