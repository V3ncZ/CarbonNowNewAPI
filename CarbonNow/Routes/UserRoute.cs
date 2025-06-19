using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Response;
using CarbonNow.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonNow.Controllers
{
    public static class UserRoute
    {

       public static void UserRoutes(this WebApplication app)
        {

            var route = app.MapGroup("User");

            route.MapGet("/ListAll", ([FromServices]DAL<User> dal) =>
            {
                var ArtistList = dal.ListAll();
                if (ArtistList is null)
                {
                    return Results.NoContent();
                }

                var artistListResponse = EntityListToResponseList(ArtistList);

                return Results.Ok(ArtistList);
            });

            route.MapPost("/Create", ([FromBody] UserRequest userRequest,[FromServices]DAL<User> dal) =>
            {
                var user = new User(userRequest.nome, userRequest.email, userRequest.dtCadastro);
                dal.Create(user);

                return Results.Ok(user);
            });
        }

        private static ICollection<UserResponse> EntityListToResponseList(IEnumerable<User> UserList)
        {
            return UserList.Select(a => EntityToResponse(a)).ToList();
        }

        private static UserResponse EntityToResponse(User user)
        {
            return new UserResponse(user.Id, user.Nome, user.Email, user.DtCadastro);
        }

    }
}
