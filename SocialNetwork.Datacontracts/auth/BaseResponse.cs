using SocialNetwork.Datacontracts.@base;

namespace SocialNetwork.DataContracts.auth;

public record BaseResponse(string? Token = null, string? Error = null) : IResponse;