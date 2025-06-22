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
            var route = app.MapGroup("ElectricalItem");

            route.MapGet("/ListAll", ([FromServices] DAL<ElectricalItem> dal) =>
            {
                var electricalItems = dal.ListAll();
                if (electricalItems is null)
                {
                    return Results.NoContent();
                }

                return Results.Ok(electricalItems);
            });

            route.MapPost("/Create", ([FromBody] ElectricalItemRequest electricalItemRequest, [FromServices] DAL<ElectricalItem> dal) =>
            {
                var electrialItem = new ElectricalItem(
                    electricalItemRequest.id,
                    electricalItemRequest.nomeItem,
                    electricalItemRequest.consumoKw,
                    electricalItemRequest.dtUso,
                    electricalItemRequest.emissaoCalculada);

                dal.Create(electrialItem);

                return Results.Ok(electrialItem);
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
                electricalItemRequest.nomeItem,
                electricalItemRequest.consumoKw,
                electricalItemRequest.dtUso,
                electricalItemRequest.emissaoCalculada);

                dal.Update(electricalItem);

                return Results.Ok(electricalItem);
            });
        }

        private static ICollection<ElectricalItemResponse> EntityListToResponseList(IEnumerable<ElectricalItem> electricalItem)
        {
            return electricalItem.Select(a => )
        }

        private static ElectricalItemResponse EntityToResponse(ElectricalItem electricalItem)
        {
            return new TransportResponse(
                electricalItem.Id,
                electricalItem.IdUsuario,
                electricalItem.NomeItem,
                electricalItem.ConsumoKwh,
                electricalItem.DtUso,
                electricalItem.EmissaoCalculada)
        }
    }
}
