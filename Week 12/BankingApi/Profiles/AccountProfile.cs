using AutoMapper;
using BankingApi.DTOs;
using BankingApi.Models;

namespace BankingApi.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // User DTO with Masking
            CreateMap<Account, UserAccountDTO>()
                .ForMember(dest => dest.MaskedAccountNumber,
                    opt => opt.MapFrom(src =>
                        MaskAccount(src.AccountNumber)
                    ));

            // Admin DTO
            CreateMap<Account, AdminAccountDTO>();
        }

        private string MaskAccount(string accNumber)
        {
            if (string.IsNullOrEmpty(accNumber))
                return "";

            if (accNumber.Length <= 4)
                return accNumber;

            var visibleDigits = accNumber.Substring(accNumber.Length - 4);

            return new string('X', accNumber.Length - 4) + visibleDigits;
        }
    }
}