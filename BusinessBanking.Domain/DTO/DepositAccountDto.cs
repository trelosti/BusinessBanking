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
    public class DepositAccountDto : BaseAccountDto
    {
        [Display(Name = "OpenDate")]
        [JsonProperty(Order = 1)]
        public DateTime OpenDate { get; set; }

        [Display(Name = "EndDate")]
        [JsonProperty(Order = 2)]
        public DateTime EndDate { get; set; }

        [Display(Name = "AvailableBalance")]
        [JsonProperty(Order = 3)]
        public decimal AvailableBalance { get; set; }

        [Display(Name = "Name")]
        [JsonProperty(Order = 4)]
        public string Name { get; set; }

        [Display(Name = "CurrencySymbol")]
        [JsonProperty(Order = 5)]
        public string CurrencySymbol { get; set; }

        [Display(Name = "AccountNo")]
        [JsonProperty(Order = 6)]
        public string AccountNo { get; set; }

        [Display(Name = "CurrencyID")]
        [JsonProperty(Order = 7)]
        public int CurrencyID { get; set; }
    }
}
