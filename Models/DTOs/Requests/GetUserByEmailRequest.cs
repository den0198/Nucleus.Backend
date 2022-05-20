﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.DTOs.Requests;

public sealed class GetUserByEmailRequest
{
    [JsonPropertyName("email")]
    [Required]
    public string Email { get; set; }
}