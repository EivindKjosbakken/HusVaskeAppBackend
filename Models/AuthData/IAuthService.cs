﻿using HusVaskeIdeBackend.Models.AuthData;

    namespace HusVaskeIdeBackend.Models.AuthData
    {
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthData GetAuthData(string id, string username);
    }
}