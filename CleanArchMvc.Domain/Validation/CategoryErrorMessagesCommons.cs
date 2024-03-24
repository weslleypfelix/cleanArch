using CleanArchMvc.Domain.Validation.Enum;

namespace CleanArchMvc.Domain.Validation
{
    internal class CategoryErrorMessagesCommons
    {
        public static string GetCategoryErrorMessage(CategoryErrorType errorType)
        {
            switch (errorType)
            {
                case CategoryErrorType.InvalidName:
                    return "Invalid name. Name is required.";

                case CategoryErrorType.InvalidLengthName:
                    return "Invalid name, too short! Minimum 3 characters";

                case CategoryErrorType.InvalidId:
                    return "Invalid id value";

                default:
                    return "An unknown error has occurred";
            }
        }
    }
}
