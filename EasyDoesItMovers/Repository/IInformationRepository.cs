using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Repository
{
    public interface IInformationRepository
    {
        public Task<Information> GetInformationPage(string slug);
        public Task AddInformationPage(Information information);
        public Task DeleteInformationPage(string slug);
        public Task<IEnumerable<InformationViewModel>> GetInformationPages();
        public Task<IEnumerable<Information>> GetInformationPagesAdmin();
        public Information GetInformationPageFromMemory(string slug);
        public Task<Information> UpdateInformation(Information information);
    }
}
