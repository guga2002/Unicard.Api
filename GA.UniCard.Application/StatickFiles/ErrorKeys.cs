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
        public const string BadRequest = " Bad request, Server do not give good response";

        /// <summary>
        /// Unsuccessful insert error message.
        /// </summary>
        public const string UnsuccesfullInsert = "Insert was not succesfull";

        /// <summary>
        /// Unsuccessful update error message.
        /// </summary>
        public const string UnsucessfullUpdate = "Update was not succesfully";

        /// <summary>
        /// Not found error message.
        /// </summary>
        public const string NotFound = "Not Found any relate Entities";

        /// <summary>
        /// No order exists error message.
        /// </summary>
        public const string NoOrder = "No order exist";

        /// <summary>
        /// Customer does not exist error message.
        /// </summary>
        public const string NoCustommer = "Custumer no  exist";

        /// <summary>
        /// Internal server error message.
        /// </summary>
        public const string InternalServerError = " there  was internall error";

        /// <summary>
        /// Date validation error message.
        /// </summary>
        public const string DateValidation = "Datetime format is  not right, YOu arer under age  10 year is allowed!";

        /// <summary>
        /// Mapping error message.
        /// </summary>
        public const string Mapped = "Mapped  not was succesfully";

        /// <summary>
        /// General exception error message.
        /// </summary>
        public const string General = " General Exception while send request";

        /// <summary>
        /// Argument null error message.
        /// </summary>
        public const string ArgumentNull = " Argument is null , please check";

        /// <summary>
        /// No such product exists error message.
        /// </summary>
        public const string NoProduct = "No Such Product Exist in DB!";

        /// <summary>
        /// Model state error message.
        /// </summary>
        public const string ModelState = "Model State is not valid!";
    }
}
