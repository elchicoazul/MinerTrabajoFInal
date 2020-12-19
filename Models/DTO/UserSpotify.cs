using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace MinerTrabajoFInal.Models.DTO
{
    public class UserSpotify{
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("followers")]
        public Followers followers { get; set; }
    }

    public class Followers
    {
        [JsonPropertyName("total")]
        [Display(Name="Followers")]
        public int Total { get; set; }
    }

}