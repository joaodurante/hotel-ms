namespace Application.Responses
{
    public enum ErrorCodes
    {
        NOT_FOUND = 1,
        COULDNOT_STORE_DATA = 2,
        MISSING_REQUIRED_FIELDS = 3,
        INVALID_PERSON_EMAIL = 4,
        INVALID_PERSON_DOCUMENT = 5,
    }

    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorCodes Error { get; set; }
    }
}
