using System.ComponentModel.DataAnnotations;
namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        public string Name{get;set;}
        [Required]
        public string TheQuote{get;set;}

    }
}