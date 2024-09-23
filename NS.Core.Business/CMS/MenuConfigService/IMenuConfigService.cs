using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.MenuConfig;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.MenuConfigService
{
    public interface IMenuConfigService
    {
        IQueryable<MenuConfig> GetAll();
        IQueryable<MenuConfig> GetById(long id);
        GetAllMenuConfigResponeModel GetMenuConfigById(long id);
        Task<List<GetAllMenuConfigResponeModel>> GetAllMenuConfigPage();
        Task<List<MenuConfigResponseModel>> GetAllAvailableDropDown();
        Task AddMenu(MenuConfigRequestModel data,string linkAnh);
        Task UpdateMenu(EditMenuConfigRequestModel update,string linkAnh);
        Task DeleteMenu(long id);
        List<MenuConfigResponseModel> GetAllMenuConfigIsActive();
        void ShowHideMenuConfig(long id);
        List<GetAllMenuConfigResponeModel> GetMenuConfigC1C2();
    }
}