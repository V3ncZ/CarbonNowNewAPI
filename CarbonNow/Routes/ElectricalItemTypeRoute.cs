using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Response;
using CarbonNow.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonNow.Routes
{
    public static class ElectricalItemTypeRoute
    {
        public static void ElectricalItemTypeRoutes(this WebApplication app)
        {
            var route = app.MapGroup("ElectricalItemType").WithTags("ElectricalItemType");

            route.MapGet("/ListAll", ([FromServices] DAL<ElectricalItemType> dal) =>
            {
               var electricalItemsType = dal.ListAll();
               if (electricalItemsType is null)
                {
                    return Results.NoContent();
                }
               
               var electricalItemsTypeResponse = EntityListToResponseList(electricalItemsType);
               return Results.Ok(electricalItemsTypeResponse);
            });

            route.MapPost("/Create", ([FromServices] DAL<ElectricalItemType> dal, [FromBody] ElectricalItemTypeRequest electricalItemRequest) =>
            {
                var electricalItemType = new ElectricalItemType(
                    electricalItemRequest.nome,
                    electricalItemRequest.consumo);

                dal.Create(electricalItemType);

                var electricalItemTypeResponse = EntityToResponse(electricalItemType);

                return Results.Ok(electricalItemTypeResponse);
            });

            route.MapDelete("/Delete/{id}", ([FromServices] DAL<ElectricalItemType> dal, [FromRoute] int id) =>
            {
                var electricalItemType = dal.RecuperarPor(a =>  a.Id == id);
                if (electricalItemType is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(electricalItemType);

                return Results.NoContent();

            });

            route.MapPut("/Update/{id}", ([FromServices] DAL<ElectricalItemType> dal, [FromBody] ElectricalItemTypeRequest electricalItemRequest, [FromRoute] int id) =>
            {
                var electricalItemType = dal.RecuperarPor(a => a.Id == id);
                if (electricalItemType is null)
                {
                    return Results.NotFound();
                }

                electricalItemType = new ElectricalItemType(
                    electricalItemRequest.id,
                    electricalItemRequest.nome,
                    electricalItemRequest.consumo);

                dal.Update(electricalItemType);

                var electricalItemTypeResponse = EntityToResponse(electricalItemType);

                return Results.Ok(electricalItemTypeResponse);
            });
        }

        private static ICollection<ElectricalItemTypeResponse> EntityListToResponseList(IEnumerable<ElectricalItemType> electricalItemType)
        {
            return electricalItemType.Select(a => EntityToResponse(a)).ToList();
        }

        private static ElectricalItemTypeResponse EntityToResponse(ElectricalItemType electricalItemType)
        {
            return new ElectricalItemTypeResponse(
                electricalItemType.Id,
                electricalItemType.Nome,
                electricalItemType.ConsumoKwhPorHora);
        }

    }
}
