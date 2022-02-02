using code_gen_web_api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SomeTestMethods>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

code_gen_web_api.EndpointBuilder.BuildEndpoints(app);

app.MapPost("/NoParamReturnVal", (SomeTestMethods methods) => methods.NoParamReturnVal()).WithName("NoParamReturnVal");
app.MapPost("/ParamReturnVal", (SomeTestMethods methods, string value) => methods.ParamReturnVal(value)).WithName("ParamReturnVal");

app.Run();