// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcRiraTheTest;

Console.WriteLine("Hello, World!");

using var channel = GrpcChannel.ForAddress("http://localhost:5192");

var person = new PersonCrud.PersonCrudClient(channel);

var reply = await person.GetAllPersonsAsync(new Empty());

foreach(var i in reply.Persons)
{
    Console.WriteLine(i.FirstName);
}

var personAddResult = person.AddPerson(new AddPersonRequestMessage() { BirthDate = 1, FirstName = "test2", LastName = "test3", NationlaCode = "1234567890" });


Console.WriteLine("All persons", personAddResult.Message);

