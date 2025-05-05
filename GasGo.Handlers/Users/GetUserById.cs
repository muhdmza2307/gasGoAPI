using System;
using System.Collections.Generic;
using GasGo.Common.Extensions;
using GasGo.Data.Entities;
using GasGo.Handlers.Interface;
using GasGo.Repositories.Repositories.Interfaces;

namespace GasGo.Handlers.Users
{
    public class GetUserById
    {
        public record GetUserByIdQuery(string ExternalUserId);
        public record GetUserByIdResponse(Guid UserId, 
            string DisplayName, 
            string PhoneNo, 
            string ExternalUserId,
            IEnumerable<GetUserRoleResponse>? UserRoles,
            DateTime? CreatedAt);

        public record GetUserRoleResponse(Guid Id,
            int RoleId,
            string RoleName,
            IEnumerable<GetUserVehicleResponse>? UserVehicles);

        public record GetUserVehicleResponse(Guid Id,
            string PlateNo,
            int FuelTypeId,
            string FuelTypeName);


        public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdResponse?>
        {
            private readonly IUserRepository _repo;

            public GetUserByIdHandler(IUserRepository repo)
            {
                _repo = repo;
            }

            public async Task<GetUserByIdResponse?> Handle(GetUserByIdQuery query)
            {
                var user = await _repo.GetWithFullDetailsAsync(query.ExternalUserId);
                var userRole = user?.UserRoles;

                return user is not null
                    ? new GetUserByIdResponse(user.Id, 
                    user.Name, 
                    user.ContactNo, 
                    user.ExternalUserId,
                    MapToUserRoles(),
                    user.DateCreated)
                    : null;


                //Local Functions
                IEnumerable<GetUserRoleResponse>? MapToUserRoles() => 
                    userRole?.Select(MapToEachUserRole);
            }

            private static GetUserRoleResponse MapToEachUserRole(UserRole userRole)
            {
                return new(userRole.Id,
                    (int)userRole.RoleId,
                    userRole.RoleId.GetEnumDescription(),
                    MapToUserVehicles(userRole.UserVehicles));


                //Local Functions
                static IEnumerable<GetUserVehicleResponse>? MapToUserVehicles(IEnumerable<UserVehicle> userVehicles) =>
                    userVehicles?.Select(MapToEachUserVehicle);
            }

            private static GetUserVehicleResponse MapToEachUserVehicle(UserVehicle userVehicle) =>
                new(userVehicle.Id, 
                    userVehicle.PlateNumber,
                    (int)userVehicle.FuelTypeId,
                    userVehicle.FuelTypeId.GetEnumDescription());

        }
    }
}
