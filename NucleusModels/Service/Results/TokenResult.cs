﻿namespace NucleusModels.Service.Results;

public sealed record TokenResult(
    string AccessToken, 
    string RefreshToken);