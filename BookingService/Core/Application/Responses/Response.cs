namespace Application.Responses
{
    public enum ErrorCodes
    {
        // generic error codes
        NOT_FOUND = 1,
        COULDNOT_STORE_DATA = 2,
        MISSING_REQUIRED_FIELDS = 3,

        // guests error codes
        INVALID_PERSON_EMAIL = 11,
        INVALID_PERSON_DOCUMENT = 12,

        // rooms error codes
        ROOM_CANNOT_BE_BOOKED = 21,

        // payment error codes
        INVALID_PAYMENT_INTENTION = 31
    }

    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorCodes Error { get; set; }
    }
}
