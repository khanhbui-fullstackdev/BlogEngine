using BlogEngine.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Web.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string ContactName { get; set; }

        [
            EmailAddress(ErrorMessage = ErrorMessage.InvalidEmail),
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredEmail),
            MinLength(12, ErrorMessage = ErrorMessage.MinLengthEmail),
            MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthEmail)]
        public string ContactEmail { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthMessage),
            MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthMessage)]        
        public string Content { get; set; }

        public string CaptchaCode { get; set; }
    }
}