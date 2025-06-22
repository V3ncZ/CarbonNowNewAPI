using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Response;
using CarbonNow.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonNow.Routes
{
    public static class UserRoute
    {

       public static void UserRoutes(this WebApplication app)
        {

            var route = app.MapGroup("User");

            route.MapGet("/ListAll", ([FromServices]DAL<User> dal) =>
            {
                var userList = dal.ListAll();
                if (userList is null)
                {
                    return Results.NoContent();
                }

                var userListResponse = EntityListToResponseList(userList);

                return Results.Ok(userListResponse);
            });

            route.MapPost("/Create", ([FromBody] UserRequest userRequest,[FromServices]DAL<User> dal) =>
            {
                var user = new User(userRequest.nome, userRequest.email, userRequest.dtCadastro);
                dal.Create(user);

                var userResponse = EntityToResponse(user);

                return Results.Ok(userResponse);
            });

            route.MapDelete("/Delete/{id}", ([FromServices] DAL<User> dal, [FromRoute] int id) =>
            {
                var user = dal.RecuperarPor(a => a.Id == id);
                if(user is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(user);
                return Results.Ok();
            });

            route.MapPut("/Update/{id}", ([FromBody] UserRequest userEdit, [FromServices] DAL<User> dal, [FromRoute] int id) =>
            {
                var user = dal.RecuperarPor(a => a.Id == id);
                if (user is null)
                {
                    return Results.NotFound();
                }

                user.Nome = userEdit.nome;
                user.Email = userEdit.email;

                dal.Update(user);

                var userListResponse = EntityToResponse(user);

                return Results.Ok(userListResponse);
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
