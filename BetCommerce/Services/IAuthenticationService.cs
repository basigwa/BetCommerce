using BetCommerce.Models.Authentication;
using System.Collections.Generic;

namespace BetCommerce.Services
{
    public interface IAuthenticationService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AccountResponse Create(CreateRequest model);
        void Delete(int id);
        void ForgotPassword(ForgotPasswordRequest model, string origin);
        IEnumerable<AccountResponse> GetAll();
        AccountResponse GetById(int id);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void Register(RegisterRequest model);
        void ResetPassword(ResetPasswordRequest model);
        void RevokeToken(string token, string ipAddress);
        AccountResponse Update(int id, UpdateRequest model);
        void ValidateResetToken(ValidateResetTokenRequest model);
        void VerifyEmail(string token);
    }
}