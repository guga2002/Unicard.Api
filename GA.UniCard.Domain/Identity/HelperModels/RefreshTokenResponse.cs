﻿namespace GA.UniCard.Domain.Identity.HelperModels
{
    public class RefreshTokenResponse
    {
        public string UserId { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
