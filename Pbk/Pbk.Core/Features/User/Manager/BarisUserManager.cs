using Pbk.Core.Features.User;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Pbk.Core.Features.Users.Manager;
using Pbk.Core.Features.Users;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Pbk.Entities.Models2;
using MediatR;

namespace Pbk.Core.Features.Users.Manager
{
    public class BarisUserManager : IUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private HttpContext context;
        private ClaimsIdentity Identities;
        private IUserDBRepository _userDBRepository;
        private IAuthorityRepository _authorityRepository;
        private IPageRepository _pageRepository;
        private IPagePermissionRepository _pagePermissionRepository;
        private IDepartmentRepository _departmentRepository;

        public BarisUserManager(
            IDepartmentRepository departmentRepository,
            IHttpContextAccessor httpContextAccessor,
            IUserDBRepository userDBRepository,
             IAuthorityRepository authorityRepository,
            IPageRepository pageRepository,
            IPagePermissionRepository pagePermissionRepository)
        {
            _userDBRepository = userDBRepository;
            //     _kullaniciYetkiliDepartmanRepository = kullaniciYetkiliDepartmanRepository;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            context = _httpContextAccessor.HttpContext;
            Identities = context.User.Identities.FirstOrDefault();
            _authorityRepository = authorityRepository;
            _pageRepository = pageRepository;
            this._pagePermissionRepository = pagePermissionRepository;
            _departmentRepository = departmentRepository;
            //   _gnlKullaniciRepository = gnlKullaniciRepository;
            //   _gnlDepartmanRepository = gnlDepartmanRepository;   
        }

        public string Audience()
        {
                     return context.Request.Headers["aud"];
        }

        public string AppVersion()
        {
            return context.Request.Headers["v"];
        }

        public Claim getClaim(string type)
        {
            return Identities.Claims.FirstOrDefault(w => w.Type == type);
        }

        public string DepartmentId()
        {
            return context.Request.Headers["departmentId"];
        }

        public string Email()
        {
            return getClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }

        public long Exp()
        {
            return Convert.ToInt64(context.Request.Headers["exp"]);
        }

        public string FirstName()
        {
            return getClaim("firs_name").Value;
        }

        public string Issuer()
        {
            return getClaim("iss").Value;
        }

        public string LanguageId()
        {
            return getClaim("languageId").Value;
        }

        public int UserId()
        {
            var id = getClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            return Convert.ToInt32(id);
        }

        public string NameLastname()
        {
            return getClaim("nameLastname").Value;
        }

        public long Nbf()
        {
            var nbf = getClaim("nbf").Value;
            return Convert.ToInt64(nbf);
        }

        public string Phone()
        {
            //return context.Request.Headers["phone"];
            return getClaim("phone").Value;
        }

        public string RoleId()
        {
            return getClaim("roleId").Value;
        }

        public Entities.Models.User? UserInfo()
        {
            var uid = this.UserId();
            if (uid > 0)
            {
                var user = _userDBRepository.GetWhere(w => w.UserId == uid).FirstOrDefault();

                if (user != null)
                {
                    return user;
                }

                return null;
            }

            return null;
        }

        //public GnlKullanici? GnlUser()
        //{
        //    var uid = this.UserInfo().Kodu;
        //    if (uid > 0)
        //    {
        //        var user = _gnlKullaniciRepository.GetWhere(w => w.kodu == uid).FirstOrDefault();
        //        if (user != null)
        //        {
        //            return user;
        //        }
        //        return null;
        //    }
        //    return null;
        //}


        public string UTCOffset()
        {
            return getClaim("UTCOffset").Value;
        }

        public bool isPermesion(string pageName, string PermissionType, int? departmentId)
        {

            if (this.UserInfo().RoleId == 1) return true;

            var user = this.UserInfo().UserId;

            var result = (from p in _pageRepository.GetAll()
                          join pp in _pagePermissionRepository.GetAll() on p.PageId equals pp.PageId into ppGroup
                          from pp in ppGroup.DefaultIfEmpty()
                          join a in _authorityRepository.GetAll() on pp.PagePermissionId equals a.PagePermissionId into aGroup
            from a in aGroup.DefaultIfEmpty()
            where p.PageName == pageName
                                && pp.PermissionType == PermissionType
                                && a.UserID == user 
                                && (departmentId.HasValue ? a.DepartmentId ==departmentId : (1==1))
                                && a.HasPermission == true
                          select p).Count();
            
            return result > 0;

        }


        public List<int> getDepartmansPagePerms(string pageName, string PermissionType)
        {
        
            var user = this.UserInfo().UserId;

            var result = (from p in _pageRepository.GetAll()
                          join pp in _pagePermissionRepository.GetAll() on p.PageId equals pp.PageId into ppGroup
                          from pp in ppGroup.DefaultIfEmpty()
                          join a in _authorityRepository.GetAll() on pp.PagePermissionId equals a.PagePermissionId into aGroup
                          from a in aGroup.DefaultIfEmpty()
                          where (this.UserInfo().RoleId == 1 ? 1==1 :  (p.PageName == pageName
                                              && pp.PermissionType == PermissionType
                                              && a.UserID == user
                                              && a.HasPermission == true)) && a.DepartmentId!=null 
                          select new
                          {
                              a.DepartmentId
                          }).Distinct().Select(w => w.DepartmentId)
                               .ToList();

            return result;
        }
        public List<int> getAllDepartmans() {
            List<int> result = new List<int>();

            result = (from authority in _authorityRepository.GetAll()
                      join department in _departmentRepository.GetAll()
                      on authority.DepartmentId equals department.DepartmentId into deptGroup
                      from dept in deptGroup.DefaultIfEmpty()
                      where   authority.UserID == this.UserInfo().UserId && authority.HasPermission == true
                      select new
                      {
                          dept.DepartmentId
                      })
                               .Distinct().Select(w => w.DepartmentId)
                               .ToList();

            return result;
        }

        public List<int> getDepartmans()
        {
            List<int> result = new List<int>();

            result = (from authority in _authorityRepository.GetAll()
                        join department in _departmentRepository.GetAll()
                        on authority.DepartmentId equals department.DepartmentId into deptGroup
                        from dept in deptGroup.DefaultIfEmpty()
                        where authority.PageId == 10 &&
                       authority.PagePermissionId == 68 &&
                              authority.UserID == this.UserInfo().UserId  && authority.HasPermission == true
                      select new
                        {
                            dept.DepartmentId 
                        })
                               .Distinct().Select(w=>w.DepartmentId)
                               .ToList();

            return result;
        }
    }
}
