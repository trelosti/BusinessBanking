﻿using BusinessBanking.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessBanking.Domain.DTO
{
    public class AccountListDto<T> where T : BaseAccountDto
    {
        [Display(Name = "Text")]
        [JsonProperty(Order = 1)]
        [JsonPropertyName("Text")]
        public string Text { get; set; }
        [Display(Name = "AccountType")]
        [JsonProperty(Order = 2)]
        [JsonPropertyName("AccountType")]
        public AccountType AccountType { get; set; }
        [Display(Name = "Items")]
        [JsonProperty(Order = 3)]
        [JsonPropertyName("Items")]
        public ICollection Items { get; set; }
    }
}
