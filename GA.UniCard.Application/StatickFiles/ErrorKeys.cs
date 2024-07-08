namespace GA.UniCard.Application.StatickFiles
{
    /// <summary>
    /// Error message constants used throughout the application.
    /// </summary>
    public static class ErrorKeys
    {
        /// <summary>
        /// Bad request error message.
        /// </summary>
        public const string BadRequest = "Bad request. Server did not respond correctly.";

        /// <summary>
        /// Unsuccessful insert error message.
        /// </summary>
        public const string UnsuccesfullInsert = "Insertion was unsuccessful.";

        /// <summary>
        /// Unsuccessful update error message.
        /// </summary>
        public const string UnsucessfullUpdate = "Update was unsuccessful.";

        /// <summary>
        /// Not found error message.
        /// </summary>
        public const string NotFound = "No related entities found.";

        /// <summary>
        /// No order exists error message.
        /// </summary>
        public const string NoOrder = "No order exists.";

        /// <summary>
        /// Customer does not exist error message.
        /// </summary>
        public const string NoCustomer = "Customer does not exist.";

        /// <summary>
        /// Internal server error message.
        /// </summary>
        public const string InternalServerError = "Internal server error occurred.";

        /// <summary>
        /// Date validation error message.
        /// </summary>
        public const string DateValidation = "Date format is incorrect. Age must be at least 10 years.";

        /// <summary>
        /// Mapping error message.
        /// </summary>
        public const string Mapped = "Mapping was not successful.";

        /// <summary>
        /// General exception error message.
        /// </summary>
        public const string General = "General exception occurred while processing request.";

        /// <summary>
        /// Argument null error message.
        /// </summary>
        public const string ArgumentNull = "Argument is null. Please check.";

        /// <summary>
        /// No such product exists error message.
        /// </summary>
        public const string NoProduct = "No such product exists in the database.";

        /// <summary>
        /// Model state error message.
        /// </summary>
        public const string ModelState = "Model state is not valid.";
    }
}
