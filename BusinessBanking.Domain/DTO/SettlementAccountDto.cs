using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessBanking.Domain.DTO
{
    public class SettlementAccountDto : BaseAccountDto
    {
        [Display(Name = "AvailableBalance")]
        [JsonProperty(Order = 1)]
        [JsonPropertyName("AvailableBalance")]
        public decimal AvailableBalance { get; set; }

        [Display(Name = "Name")]
        [JsonProperty(Order = 2)]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [Display(Name = "CurrencySymbol")]
        [JsonProperty(Order = 3)]
        [JsonPropertyName("CurrencySymbol")]
        public string CurrencySymbol { get; set; }

        [Display(Name = "AccountNo")]
        [JsonProperty(Order = 4)]
        [JsonPropertyName("AccountNo")]
        public string AccountNo { get; set; }

        [Display(Name = "CurrencyID")]
        [JsonProperty(Order = 5)]
        [JsonPropertyName("CurrencyID")]
        public int CurrencyID { get; set; }
    }
}
