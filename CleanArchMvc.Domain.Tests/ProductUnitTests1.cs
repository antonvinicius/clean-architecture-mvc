using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTests1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Mouse", "Mouse gamer", 149.99m, 100, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeId_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(-1, "teste", "teste", 48.3m, 3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_NullName_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(3, "", "teste", 48.3m, 3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateProduct_TooShortName_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(1, "pr", "teste", 48.3m, 3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_NullDescription_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(1, "teste", "", 48.3m, 3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact]
        public void CreateProduct_TooShortDescription_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(1, "teste", "tes", 48.3m, 3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. mininum 5 characters");
        }

        [Fact]
        public void CreateProduct_NegativePrice_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(1, "teste", "teste", -1, 3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateProduct_NegativeStock_ResultDomainExceptionInvalid()
        {
            Action action = () => new Product(1, "teste", "teste", 1, -3, "teste");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact]
        public void CreateProduct_ImageTooBig_ResultDomainExceptionInvalid()
        {
            // String com 251 caracteres
            Action action = () => new Product(1, "teste", "teste", 48.3m, 3, "0izV9DwOl0G7d2QVBNvALIBp9RrluENExthhykR9qFifMhNXB8bPvU3sEvdEPHfqkyShXfgmZOec2uuk1wujoyUMNUiAYhjdDS8teu5kAcebBwh2Py1LVAyhFoWLPpkZBGPgzWAlhcPbUsNlt8eXmEOmmZLVqApHqIscrjUC4jXpzm9YjYVm160rTALbm3I91JE0Nd4qkmH4n21Ft7ow41998oaHuvBbg5vWPGsO1w2wM7GjaN8y3Lv0WL5");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_NullImage_ResultValidState()
        {
            Action action = () => new Product(1, "teste", "teste", 48.3m, 3, null);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NullImage_NoNullReferenceException()
        {
            Action action = () => new Product(1, "teste", "teste", 48.3m, 3, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
