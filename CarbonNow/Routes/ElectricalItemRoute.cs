using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Response;
using CarbonNow.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonNow.Routes
{
    public static class ElectricalItemRoute
    {
        public static void ElectricalItemRoutes(this WebApplication app)
        {
            var route = app.MapGroup("ElectricalItem").WithTags("ElectricalItem");

            route.MapGet("/ListAll", ([FromServices] DAL<ElectricalItem> dal) =>
            {
                var electricalItems = dal.ListAll();
                if (electricalItems is null)
                {
                    return Results.NoContent();
                }

                var electricalItemResponseList = EntityListToResponseList(electricalItems);

                return Results.Ok(electricalItemResponseList);
            });

            route.MapPost("/Create", ([FromBody] ElectricalItemRequest electricalItemRequest, [FromServices] DAL<ElectricalItem> dal) =>
            {
                var electrialItem = new ElectricalItem(
                    electricalItemRequest.id,
                    electricalItemRequest.tipoItemEletricoId,
                    electricalItemRequest.duracaoUsoHoras,
                    electricalItemRequest.dtUso);

                dal.Create(electrialItem);

                var electrialItemResponse = EntityToResponse(electrialItem);

                return Results.Ok(electrialItemResponse);
            });

            route.MapDelete("/Delete/{id}", ([FromServices] DAL<ElectricalItem> dal, [FromRoute] int id) =>
            {
                var electricalItem = dal.RecuperarPor(a => a.Id == id);
                if (electricalItem is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(electricalItem);

                return Results.NoContent();
            });

            route.MapPut("/Update/{id}", ([FromBody] ElectricalItemRequest electricalItemRequest, [FromServices] DAL<ElectricalItem> dal, [FromRoute] int id) =>
            {
            var electricalItem = dal.RecuperarPor(a => a.Id == id);
            if (electricalItem is null)
            {
                return Results.NotFound();
            }

            electricalItem = new ElectricalItem(
                electricalItemRequest.id,
                electricalItemRequest.tipoItemEletricoId,
                electricalItemRequest.duracaoUsoHoras,
                electricalItemRequest.dtUso);

                dal.Update(electricalItem);

                var electricalItemResponse = EntityToResponse(electricalItem);

                return Results.Ok(electricalItemResponse);
            });
        }

        private static ICollection<ElectricalItemResponse> EntityListToResponseList(IEnumerable<ElectricalItem> electricalItem)
        {
            return electricalItem.Select(a => EntityToResponse(a)).ToList();
        }

        private static ElectricalItemResponse EntityToResponse(ElectricalItem electricalItem)
        {
            return new ElectricalItemResponse(
                electricalItem.Id,
                electricalItem.IdUsuario,
                electricalItem.DtUso,
                electricalItem.EmissaoCalculada,
                electricalItem.DuracaoUsoHoras);
        }
    }
}
