using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnityTests1
    {
        [Fact(DisplayName = "Create product with a valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Iphone 13", "Product", 0.29m, 1000, "x.png");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Throw exception in case of null name")]
        public void CreateProduct_WithNullName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(null, "Product", 0.29m, 1000, "x.png");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Throw exception in case of empty name")]
        public void CreateProduct_WithInvalidName_DomainExceptionInvalidName()
        {
            Action action = () => new Product("", "Product", 0.29m, 1000, "x.png");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Throw exception in case of a too short name")]
        public void CreateProduct_WithShortdName_DomainExceptionInvalidName()
        {
            Action action = () => new Product("We", "Product", 0.29m, 1000, "x.png");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short! Minimum 3 characters");
        }

        [Fact(DisplayName = "Throw exception in case of a invalid description")]
        public void CreateProduct_WithInvalidDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product("Iphone 13", "", 0.29m, 1000, "x.png");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Throw exception in case of a too short description")]
        public void CreateProduct_WithTooShortDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product("Iphone 13", "aa", 0.29m, 1000, "x.png");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description. Too short, minimum 5 characters");
        }


    }
}
