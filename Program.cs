using Microsoft.EntityFrameworkCore;
using SeatManagement;
using SeatManagement.Interfaces;
using SeatManagement.Models;
using SeatManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<AllocatedAsset>, Repository<AllocatedAsset>>();
builder.Services.AddScoped<IRepository<Asset>, Repository<Asset>>();
builder.Services.AddScoped<IRepository<Building>, Repository<Building>>();
builder.Services.AddScoped<IRepository<Seat>, Repository<Seat>>();
builder.Services.AddScoped<IRepository<City>, Repository<City>>();
builder.Services.AddScoped<IRepository<Department>, Repository<Department>>();
builder.Services.AddScoped<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddScoped<IRepository<Facility>, Repository<Facility>>();
builder.Services.AddScoped<IRepository<MeetingRoom>, Repository<MeetingRoom>>();
builder.Services.AddScoped<IRepository<Seat>, Repository<Seat>>();
builder.Services.AddScoped<IRepository<CabinRoom>, Repository<CabinRoom>>();
builder.Services.AddScoped<ICabinRoomRepository, CabinRoomRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();


builder.Services.AddScoped<IAllocatedAssetsService, AllocatedAssetsService>();
builder.Services.AddScoped<IAssetsService, AssetsService>();
builder.Services.AddScoped<IBuildingsService , BuildingsService>();
builder.Services.AddScoped<ICabinRoomsService, CabinRoomsService>();
builder.Services.AddScoped<ICitiesService , CitiesService>();
builder.Services.AddScoped<IDepartmentsService , DepartmentsService>();
builder.Services.AddScoped<IEmployeesService , EmployeesService>();
builder.Services.AddScoped<IFacilitiesService, FacilitiesService>();
builder.Services.AddScoped<IMeetingRoomsService , MeetingRoomsService>();
builder.Services.AddScoped<ISeatsService, SeatsService>();



builder.Services.AddDbContext<SeatManagementDbContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
