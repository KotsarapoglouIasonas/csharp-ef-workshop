using csharp_ef_workshop.api.Model;
using csharp_ef_workshop.api.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System;

namespace csharp_ef_workshop.api.Endpoint
{
    public static class PersonApi
    {
        public static void ConfigurePersonApi(this WebApplication app)
        {
            app.MapGet("/people", GetPeople);
            app.MapGet("/people/{id}", GetAPerson);
            app.MapPost("/people", InsertPerson);
            app.MapDelete("/people/{id}", DeletePerson);
        }
        private static async Task<IResult> GetAPerson(int id, IPeopleRepository peopleRepository)
        {
            try
            {
                var result = peopleRepository.GetAPerson(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetPeople(IPeopleRepository peopleRepository)
        {
            try
            {
                return Results.Ok(peopleRepository.GetPeople());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertPerson(Person person, IPeopleRepository peopleRepository)
        {
            try
            {
                if (peopleRepository.AddPerson(person)) return Results.Ok();
                return Results.NotFound();
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeletePerson(int id, IPeopleRepository peopleRepository)
        {
            try
            {
                if (peopleRepository.DeletePerson(id)) return Results.Ok();
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
