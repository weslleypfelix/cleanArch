using CleanArchMvc.Domain.Validation;
using CleanArchMvc.Domain.Validation.Enums;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0,
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidId));
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidName));

            DomainExceptionValidation.When(name.Length < 3,
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidLengthName));

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidDescriptionIsEmpty));

            DomainExceptionValidation.When(description.Length < 5,
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidDescriptionTooShort));

            DomainExceptionValidation.When(price < 0,
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidPriceValue));

            DomainExceptionValidation.When(stock < 0,
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidStockValue));

            DomainExceptionValidation.When(image?.Length > 250,
                ProductErrorMessagesCommons.GetProductErrorMessage(ProductErrorType.InvalidImageName));

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
