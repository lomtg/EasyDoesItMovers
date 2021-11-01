using EasyDoesItMovers.Models;
using EasyDoesItMovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Repository
{
    public class InformationRepositoryInMemory : IInformationRepository
    {
        public List<Information> InformationList = new List<Information>()
        {
            new Information()
            {
                Slug = "moving-services",
                Title = "Moving Services",
                ShortDescription = "Phasellus rhoncus lorem id mauris mollis pellentesque. Mauris eu mauris malesuada.",
                Text = "<b>Phasellus</b> <i>rhoncus lorem </i>id mauris mollis pellentesque. Mauris eu mauris malesuada, dignissim metus sed, ullamcorper nunc. Curabitur porta consectetur enim quis molestie. "
            }
        };

        public Task AddInformationPage(Information information)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInformationPage(string slug)
        {
            throw new NotImplementedException();
        }

        public Information GetInformationPageFromMemory(string slug)
        {
            return InformationList.FirstOrDefault(o => o.Slug == slug);
        }

        public Task<InformationViewModel> GetInformationPage(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InformationViewModel>> GetInformationPage()
        {
            throw new NotImplementedException();
        }

        Task<Information> IInformationRepository.GetInformationPage(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InformationViewModel>> GetInformationPages()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Information>> GetInformationPagesAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<Information> UpdateInformation(string slug, Information information)
        {
            throw new NotImplementedException();
        }
    }
}
