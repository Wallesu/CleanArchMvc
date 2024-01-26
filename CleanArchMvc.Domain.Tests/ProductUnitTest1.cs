using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Tênis", "Tênis de corrida", 10.0m, 5, "image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Tênis", "Tênis de corrida", 10.0m, 5, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Tê", "Tênis de corrida", 10.0m, 5, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Tênis de corrida", 10.0m, 5, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid field. Name is required");

            Action action2 = () => new Product(1, "", "Tênis de corrida", 10.0m, 5, "image");
            action2.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid field. Name is required");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Tênis", "Têni", 10.0m, 5, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description, too short, minimum 5 characters");
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Tênis", null, 10.0m, 5, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid field. Description is required");

            Action action2 = () => new Product(1, "Tênis", "", 10.0m, 5, "image");
            action2.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid field. Description is required");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Tênis", "Tênis de corrida", -10.0m, 5, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Price value");
        }

        [Fact]
        public void CreateProduct_InvalidStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Tênis", "Tênis de corrida", 10.0m, -1, "image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Stock value");
        }

        [Fact]
        public void CreateProduct_InvalidImageValue_DomainExceptionTooLongImage()
        {
            Action action = () => new Product(1, "Tênis", "Tênis de corrida", 10.0m, 5, "AAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQAAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQAAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQAAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQAAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQAAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQAAAAAAAAAAQQQQQQQQQQAAAAAAAAAAQQQQQQQQQ");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Tênis", "Tênis de corrida", 10.0m, 5, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NotNullReferenceException()
        {
            Action action = () => new Product(1, "Tênis", "Tênis de corrida", 10.0m, 5, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

    }
}
