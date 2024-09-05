using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTranscation.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }

        [Column(TypeName ="nvarchar(12)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage ="This field is required")]
        [MaxLength(12,ErrorMessage ="Maximum 12 characters only")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Beneficiary Name")]
        [Required(ErrorMessage = "This field is required")]
        public string BeneficiaryName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "This field is required")]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("IFSC Code")]
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters only")]
        public string IFSCCode { get; set; }

        [Required(ErrorMessage = "This field is required")]  
        public int Amount { get; set; }

        public DateTime Date { get; set; }
     


    }
}
