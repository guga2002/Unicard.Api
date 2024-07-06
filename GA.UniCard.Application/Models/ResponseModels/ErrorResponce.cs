﻿namespace GA.UniCard.Application.Models.ResponseModels
{
    /// <summary>
    /// Represents an error response returned by the API.
    /// </summary>
    public class ErrorResponce
    {
        /// <summary>
        /// Gets or sets the HTTP status code of the error response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message describing the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets additional details about the error, if available.
        /// </summary>
        public string Detailed { get; set; }
    }
}
