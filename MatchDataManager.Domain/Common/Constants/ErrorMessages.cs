namespace MatchDataManager.Domain.Common.Constants;

public static class ErrorMessages
{
    private const string LengthCantBeLongerThan = "Length can't be longer than";
    private const string UniqueBase = "Unique";
    private const string IsRequiredBase = "is required";

    public static class Id
    {
        public const string NotEmpty = "Id " + IsRequiredBase;
    }

    public static class Name
    {
        public const string NotEmpty = "Name " + IsRequiredBase;
        public const string MaximumLength = LengthCantBeLongerThan + " 255";
        public const string IsUnique = UniqueBase + " Name " + IsRequiredBase;
    }

    public static class City
    {
        public const string NotEmpty = "City " + IsRequiredBase;
        public const string MaximumLength = LengthCantBeLongerThan + " 55";
    }

    public static class CoachName
    {
        public const string NotEmpty = "Coach Name " + IsRequiredBase;
        public const string MaximumLength = LengthCantBeLongerThan + " 55";
    }

    public static class Exception
    {
        public const string ErrorOccurred = "An error occurred while initializing the database.";
    }
}
