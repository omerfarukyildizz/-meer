using AutoMapper;
using Pbk.Core.Features.Drivers.Create;
using Pbk.Core.Features.Response;
using Pbk.Core.Features.User;
using Pbk.Core.Features.Users;
using Pbk.Core.Utilities.IResults;
using Pbk.Entities.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Auth.Permis
{
  
    internal sealed class PermisCommandHandler : IRequestHandler<PermisCommand, APIResponse>
    {
        private IUserManager _userManager;
        private IAuthorityRepository _authorityRepository;
        private IPageRepository _pageRepository;
        private IPagePermissionRepository _pagePermissionRepository;
        private IDepartmentRepository _departmentRepository;

        public PermisCommandHandler(IUserManager userManager, IAuthorityRepository authorityRepository, IPageRepository pageRepository, IPagePermissionRepository pagePermissionRepository, IDepartmentRepository departmentRepository)
        {
            _userManager = userManager;
            _authorityRepository = authorityRepository;
            _pageRepository = pageRepository;
            _pagePermissionRepository = pagePermissionRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<APIResponse> Handle(PermisCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userManager.UserInfo().UserId;

                var result = (from p in _pageRepository.GetAll()
                              join pp in _pagePermissionRepository.GetAll() on p.PageId equals pp.PageId into ppGroup
                              from pp in ppGroup.DefaultIfEmpty()
                              join a in _authorityRepository.GetAll() on pp.PagePermissionId equals a.PagePermissionId into aGroup
                              from a in aGroup.DefaultIfEmpty()
                              where  
                                                 a.UserID == user
                                                  && a.HasPermission == true
                              select new {
                                DepartmanId = a.DepartmentId,
                                PageName = p.PageName,
                                PermissionType = pp.PermissionType,
                });
 
                return new(status: OperationResult.Success, messages: "", result.ToList());
            }
            catch (Exception ex)
            {
                return new(status: OperationResult.Error, messages: ex.Message, null);
            }

        }

    }
}
