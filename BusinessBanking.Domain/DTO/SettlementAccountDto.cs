using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessBanking.Domain.DTO
{
    public class SettlementAccountDto : BaseAccountDto
    {
        [Display(Name = "AvailableBalance")]
        [JsonProperty(Order = 1)]
        public decimal AvailableBalance { get; set; }

        [Display(Name = "Name")]
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [Display(Name = "CurrencySymbol")]
        [JsonProperty(Order = 3)]
        public string CurrencySymbol { get; set; }

        [Display(Name = "AccountNo")]
        [JsonProperty(Order = 4)]
        public string AccountNo { get; set; }

        [Display(Name = "CurrencyID")]
        [JsonProperty(Order = 5)]
        public int CurrencyID { get; set; }
    }
}
