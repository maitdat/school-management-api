using Microsoft.EntityFrameworkCore;
using NS.Core.Business.FileService;
using NS.Core.Business.TinTucServices;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.RequestModels.MenuConfig;
using NS.Core.Models.ResponseModels;

namespace NS.Core.Business.MenuConfigService
{
    public class MenuConfigService : IMenuConfigService
    {
        private readonly AppDbContext _context;
        private readonly IFile _fileService;
        private readonly ITinTucServices _tinTucServices;

        public MenuConfigService(AppDbContext appDbContext, IFile fileService, ITinTucServices tinTucServices)
        {
            _context = appDbContext;
            _fileService = fileService;
            _tinTucServices = tinTucServices;
        }
        public IQueryable<MenuConfig> GetAll()
        {
            return _context.MenuConfig.AsQueryable();
        }
        //Read
        public IQueryable<MenuConfig> GetById(long id)
        {
            return _context.MenuConfig.Where(x => x.Id == id);
        }
        //List
        public async Task<List<MenuConfigResponseModel>> GetAllAvailableDropDown()
        {
            var result = await _context.MenuConfig.Where(c => !c.IsDeleted).ToListAsync();
            var rootNode = result.Where(c => c.ParentId is null).Select(x => new MenuConfigResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                TinTucId = x.TinTucId,
                LinkBanner = x.LinkBanner,
                Url = x.Url,
                NameEn = x.NameEn,
                IsDefault = x.IsDefault,
                Order = x.Order,
                MenuChuyenMuc = _context.MenuChuyenMuc.Where(y => y.MenuConfigId == x.Id).Select(x => new MenuChuyenMucResponseModel
                {
                    ChuyenMucId = x.ChuyenMucId
                }).ToList(),
            }).OrderBy(x => x.Order).ToList();
            FormatData(rootNode, result);
            return rootNode;
        }
        public void FormatData(List<MenuConfigResponseModel> listMenu, List<MenuConfig> data)
        {

            foreach (var root in listMenu)
            {
                var childNode = data.Where(x => x.ParentId == root.Id).Select(x => new MenuConfigResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = root.Id,
                    IsActive = x.IsActive,
                    TinTucId = x.TinTucId,
                    LinkBanner = x.LinkBanner,
                    Url = x.Url,
                    Order = x.Order,
                    NameEn = x.NameEn,
                    IsDefault = x.IsDefault,
                    MenuChuyenMuc = _context.MenuChuyenMuc.Where(y => y.MenuConfigId == x.Id).Select(x => new MenuChuyenMucResponseModel
                    {
                        ChuyenMucId = x.ChuyenMucId
                    }).ToList(),
                }).OrderBy(x => x.Order).ToList();
                root.Children = childNode;
                FormatData(root.Children, data);
            }


        }
        //Create
        public async Task AddMenu(MenuConfigRequestModel data, string linkAnh)
        {
            try
            {

                if (NameIsValid(data.Name))
                {
                    var newMenu = new MenuConfig
                    {
                        Name = data.Name,
                        ParentId = data.ParentId != 0 ? data.ParentId : null,
                        LinkBanner = linkAnh,
                        NameEn = data.NameEn,
                        Order = data.Order,
                        TinTucId = data.TinTucId
                    };
                    if (data.TinTucId != null)
                    {
                        var tinTuc = await _tinTucServices.GetTinTucById(data.TinTucId.ToString());
                        newMenu.Url = Utilities.ConvertToUrlFriendly(tinTuc.TieuDe);
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.ALREADY_EXIST, nameof(MenuConfig)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Update
        public async Task UpdateMenu(EditMenuConfigRequestModel update, string linkAnh)
        {
            try
            {
                if (GetById(update.Id).FirstOrDefault() != null)
                {
                    var updataMenuConfig = GetById(update.Id).FirstOrDefault();
                    updataMenuConfig.ParentId = update.ParentId == 0 || update.ParentId < 0 ? null : update.ParentId;
                    updataMenuConfig.Name = update.Name;
                    updataMenuConfig.LinkBanner = linkAnh == "" ? updataMenuConfig.LinkBanner : linkAnh;
                    updataMenuConfig.NameEn = update.NameEn;
                    updataMenuConfig.Order = update.Order;
                    updataMenuConfig.TinTucId = update.TinTucId;
                    if (update.TinTucId != null)
                    {
                        var tinTuc = await _tinTucServices.GetTinTucById(update.TinTucId.ToString());
                        updataMenuConfig.Url = Utilities.ConvertToUrlFriendly(tinTuc.TieuDe);
                    }
                    _context.MenuConfig.Update(updataMenuConfig);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(MenuConfig)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        //Remove
        public async Task DeleteMenu(long id)
        {
            try
            {
                if (GetById(id).FirstOrDefault() != null && GetById(id).FirstOrDefault().IsDefault == false)
                {
                    _context.MenuConfig.Delete(id);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Format(Constants.ExceptionMessage.NOT_FOUND, nameof(MenuConfig)));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool NameIsValid(string name)
        {
            return !_context.MenuConfig.Any(c => c.Name.ToLower() == name.ToLower());
        }
        //page
        public Task<List<GetAllMenuConfigResponeModel>> GetAllMenuConfigPage()
        {
            return Task.FromResult(GetAllMenuConfigResponeModels().ToList());
        }

        public GetAllMenuConfigResponeModel GetMenuConfigById(long id)
        {
            var result = GetById(id).Select(x => new GetAllMenuConfigResponeModel
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Name = x.Name,
                IsActive = x.IsActive,
                TinTucId = x.TinTucId,
                LinkBanner = x.LinkBanner,
                Url = x.Url,
                NameEn = x.NameEn,
                Order = x.Order,
                IsDefault = x.IsDefault,
                MenuChuyenMuc = x.MenuChuyenMuc.Where(y => y.MenuConfigId == x.Id).Select(c => new MenuChuyenMucResponseModel
                {
                    ChuyenMucId = c.Id,
                }).ToList(),
            }).FirstOrDefault();
            return result;
        }
        public List<MenuConfigResponseModel> GetAllMenuConfigIsActive()
        {
            var result = _context.MenuConfig.Where(c => !c.IsDeleted).ToList();
            var rootNode = result.Where(c => c.ParentId is null && c.IsActive).Select(x => new MenuConfigResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                TinTucId = x.TinTucId,
                LinkBanner = x.LinkBanner,
                Url = x.Url,
                NameEn = x.NameEn,
                IsDefault = x.IsDefault,
                Order = x.Order,
                MenuChuyenMuc = _context.MenuChuyenMuc.Where(y => y.MenuConfigId == x.Id).Select(x => new MenuChuyenMucResponseModel
                {
                    ChuyenMucId = x.ChuyenMucId
                }).ToList(),
            }).OrderBy(x => x.Order).ToList();
            FormatDataActive(rootNode, result);
            return rootNode;
        }
        public void FormatDataActive(List<MenuConfigResponseModel> listMenu, List<MenuConfig> data)
        {

            foreach (var root in listMenu)
            {
                var childNode = data.Where(x => x.ParentId == root.Id && x.IsActive).Select(x => new MenuConfigResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = root.Id,
                    IsActive = x.IsActive,
                    TinTucId = x.TinTucId,
                    LinkBanner = x.LinkBanner,
                    NameEn = x.NameEn,
                    Url = x.Url,
                    Order = x.Order,
                    MenuChuyenMuc = _context.MenuChuyenMuc.Where(y => y.MenuConfigId == x.Id).Select(x => new MenuChuyenMucResponseModel
                    {
                        ChuyenMucId = x.ChuyenMucId
                    }).ToList(),
                }).OrderBy(x => x.Order).ToList();
                root.Children = childNode;
                FormatDataActive(root.Children, data);
            }


        }
        private IQueryable<GetAllMenuConfigResponeModel> GetAllMenuConfigResponeModels()
        {
            var data = GetAll().Where(c => !c.IsDeleted).Select(c => new GetAllMenuConfigResponeModel
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Name = c.Name,
                IsActive = c.IsActive,
                TinTucId = c.TinTucId,
                LinkBanner = c.LinkBanner,
                Url = c.Url,
                NameEn = c.NameEn,
                IsDefault = c.IsDefault,
                Order = c.Order,
                MenuChuyenMuc = c.MenuChuyenMuc.Where(y => y.MenuConfigId == c.Id).Select(x => new MenuChuyenMucResponseModel
                {
                    ChuyenMucId = x.ChuyenMucId
                }).ToList(),
            });
            return data;
        }
        public void ShowHideMenuConfig(long id)
        {
            var result = _context.MenuConfig.GetAvailableById(id);
            result.IsActive = !result.IsActive;
            _context.MenuConfig.Update(result);
            _context.SaveChanges();

        }
        public List<GetAllMenuConfigResponeModel> GetMenuConfigC1C2()
        {
            var result = _context.MenuConfig.Where(x => (x.ParentId == null || x.Parent.ParentId == null) && !x.IsDeleted).Select(c => new GetAllMenuConfigResponeModel
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Name = c.Name,
                IsActive = c.IsActive,
                TinTucId = c.TinTucId,
                LinkBanner = c.LinkBanner,
                Url = c.Url,
                NameEn = c.NameEn,
                IsDefault = c.IsDefault,
                Order = c.Order,
                MenuChuyenMuc = c.MenuChuyenMuc.Where(y => y.MenuConfigId == c.Id).Select(x => new MenuChuyenMucResponseModel
                {
                    ChuyenMucId = x.ChuyenMucId
                }).ToList(),
            }).OrderBy(x => x.Order).ToList();
            return result;
        }
    }
}
