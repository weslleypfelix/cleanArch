using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with a valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Throw exception in case of a invalid id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id value");
        }

        [Fact(DisplayName = "Throw exception in case of empty name")]
        public void CreateCategory_EmptyNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Throw exception in case of null name")]
        public void CreateCategory_NullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}