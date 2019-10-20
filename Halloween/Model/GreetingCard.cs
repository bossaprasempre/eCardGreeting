using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Halloween.Model
{
    public class GreetingCard
    {

        //Add unique identifier for the database
        [Key]
        public int? ID { get; set; }

        //Recipient's Name and Email address
        [DisplayName("Friend's Name")]
        [Display(Prompt = "First & Last Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string recipientname { get; set; }

        [DisplayName("Friend's Email")]
        [Display(Prompt = "email@example.com")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string recipientemail { get; set; }


        //Sender's Name and Email address
        [DisplayName("Sender's Name")]
        [Display(Prompt = "First & Last Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string sendername { get; set; }

        [DisplayName("Sender's Email")]
        [Display(Prompt = "email@example.com")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string senderemail { get; set; }

        //Greeting Subject
        [DisplayName("Subject")]
        [Required(ErrorMessage = "Required")]
        public string subject { get; set; }

        //Greeting Message
        [DisplayName("Message")]
        [Required(ErrorMessage = "Required")]
        public string message { get; set; }

        // Fields to be included in the database
        public string createDate { get; set; }

        public string createIP { get; set; }

        public string sendDate { get; set; }

        public string sendIP { get; set; }

        // Recaptcha code
        public string reCaptcha { get; set; }



    }
}
