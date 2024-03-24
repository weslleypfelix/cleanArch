using CleanArchMvc.Domain.Validation;
using CleanArchMvc.Domain.Validation.Enum;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Base
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomainName(name);
        }

        public Category(int id, string name)
        {
            ValidateId(id);
            ValidateDomainName(name);
        }

        public void Update(string name)
        {
            ValidateDomainName(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomainName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                CategoryErrorMessagesCommons.GetCategoryErrorMessage(CategoryErrorType.InvalidName));

            DomainExceptionValidation.When(name.Length < 3,
                CategoryErrorMessagesCommons.GetCategoryErrorMessage(CategoryErrorType.InvalidLengthName));

            Name = name;
        }

        private void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, 
                CategoryErrorMessagesCommons.GetCategoryErrorMessage(CategoryErrorType.InvalidId));
            
            Id = id;
        }
    }
}
