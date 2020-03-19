using System.Collections.Generic;

namespace OpenDEVCore.Security.Dto
{
    public class ProfileTransactionsDto
    {       
        public int? IdProfile { get; set; }
        public int? IdOffice { get; set; }
        public string OfficeName { get; set; }
        public string ProfileCode { get; set; }
        public string ProfileName { get; set; }
        public List<MenuOptionDto> Transactions { get; set; }

        public ProfileTransactionsDto() { }
        public ProfileTransactionsDto(int? idProfile, string officeName, int idOffice,string profileCode, string profileName, List<MenuOptionDto> transactions)
        {
            IdProfile = idProfile;
            OfficeName = officeName;
            IdOffice = idOffice;
            ProfileCode = profileCode;
            ProfileName = profileName;
            Transactions = transactions;
        }
    }
}
