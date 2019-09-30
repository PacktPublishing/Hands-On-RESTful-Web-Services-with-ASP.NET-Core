using Catalog.Domain.Commands.Item;
using Catalog.Domain.Commands.Item.Validators;
using Catalog.Domain.Entities;
using FluentValidation.TestHelper;
using Xunit;

namespace Catalog.Domain.Tests.Commands.Item.Validators
{
    public class EditItemCommandValidatorTests
    {
        private readonly EditItemCommandValidator _validator;

        public EditItemCommandValidatorTests()
        {
            _validator = new EditItemCommandValidator();
        }

        [Fact]
        public void should_have_error_when_Id_is_null()
        {
            var editItemCommand = new EditItemCommand { Price = new Money() };
            _validator.ShouldHaveValidationErrorFor(x => x.Id, editItemCommand);
        }

        [Fact]
        public void should_have_error_when_ArtistId_is_null()
        {
            var editItemCommand = new EditItemCommand { Price = new Money() };
            _validator.ShouldHaveValidationErrorFor(x => x.GenreId, editItemCommand);
        }

        [Fact]
        public void should_have_error_when_GenreId_is_null()
        {
            var editItemCommand = new EditItemCommand { Price = new Money() };
            _validator.ShouldHaveValidationErrorFor(x => x.GenreId, editItemCommand);
        }
    }
}