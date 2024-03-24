using CleanArchMvc.Domain.Validation.Enums;

namespace CleanArchMvc.Domain.Validation
{
    internal class ProductErrorMessagesCommons
    {
        public static string GetProductErrorMessage(ProductErrorType errorType)
        {
            switch (errorType)
            {
                case ProductErrorType.InvalidName:
                    return "Invalid name. Name is required";
                case ProductErrorType.InvalidLengthName:
                    return "Invalid name, too short! Minimum 3 characters";
                case ProductErrorType.InvalidDescriptionIsEmpty:
                    return "Invalid description. Description is required";
                case ProductErrorType.InvalidDescriptionTooShort:
                    return "Invalid description. Too short, minimum 5 characters";
                case ProductErrorType.InvalidPriceValue:
                    return "Invalid price value";
                case ProductErrorType.InvalidStockValue:
                    return "Invalid stock value";
                case ProductErrorType.InvalidImageName:
                    return "Invalid Image name, too long. Maximum 250 characters";
                case ProductErrorType.InvalidId:
                    return "Invalid id value";

                default:
                    return "An unknown error has occurred";
            }
        }
    }
}
