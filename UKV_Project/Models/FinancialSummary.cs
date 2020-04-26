using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDRProject.Models
{
    [Table("BondSummary")]
    public class FinancialSummary
    {
        public FinancialSummary()
        {
        }

        [Key]
        [Column("RowId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("row_id")]
        public int RowId { get; set; }

        [Column("Date")]
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [Column("FiscalYear")]
        [JsonProperty("fiscal_year")]
        public string FiscalYear { get; set; }

        [JsonProperty("fiscal_quarter")]
        public string FiscalQuarter { get; set; }

        [JsonProperty("bond_program_year")]
        public int BondPYear { get; set; }

        [JsonProperty("proposition")]
        public string Proposition { get; set; }

        [JsonProperty("allocated")]
        public double Allocated { get; set; }

        [JsonProperty("spent_1")]
        public double Expended { get; set; }

        [JsonProperty("spent_2")]
        public int PerExpended { get; set; }

        [JsonProperty("encumbered_1")]
        public double Encumbered { get; set; }

        [JsonProperty("encumbered_2")]
        public int PerEncumbered { get; set; }

        [JsonProperty("available_1")]
        public double Availability { get; set; }

        [JsonProperty("available_2")]
        public int PerAvailability { get; set; }
    }
}