using ASP.API.Core;
using ASP.API;
using ASP.Aplication;
using ASP.Implementation;
using Microsoft.Data.SqlClient;
using System.Data;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCases.Commands.User;
using ASP.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ASP.Implementation.UseCasesIm.CommandsIm.UsersIm;
using ASP.Implementation.Validators.User;
using ASP.Implementation.Validators.Food;
using ASP.Implementation.UseCasesIm.CommandsIm.FoodIm;
using ASP.Implementation.Validators.FoodValFolder;
using ASP.Aplication.UseCases.Commands.Comment;
using ASP.Implementation.UseCasesIm.CommandsIm.CommentsIm;
using ASP.Implementation.Validators.Comment;
using ASP.Implementation.Validators.CommentValFolder;
using ASP.Aplication.UseCasesAp.Commands.Recipe;
using ASP.Implementation.UseCasesIm.CommandsIm.RecipeIm;
using ASP.Implementation.Validators.Recipe;
using ASP.Aplication.UseCases.Commands.Recipe;
using ASP.Implementation.Validators.RecipeValFolder;
using ASP.Implementation.UseCasesIm.QueriesIm;
using ASP.Implementation.UseCasesIm;
using ASP.Aplication.UseCases.Commands.EmailSend;
using ASP.Implementation.UseCasesIm.EmailSendIm;
using Microsoft.Extensions.Configuration;
using ASP.Aplication.DTO;
using ASP.Aplication.UseCasesAp.Commands.Contact;
using ASP.Implementation.UseCasesIm.CommandsIm.ContactIm;
using ASP.Implementation.Validators.ContactValFolder;
using ASP.Aplication.UseCasesAp.Commands.Rate;
using ASP.Implementation.UseCasesIm.CommandsIm.RateIm;
using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.DTO.RateAp;
using ASP.Aplication.UseCasesAp.Commands.Reaction;
using ASP.Implementation.UseCasesIm.CommandsIm.ReactionIm;
using ASP.Aplication.DTO.ReactionAp;
using ASP.Aplication.UseCasesAp.Commands.Category;
using ASP.Aplication.DTO.CategoryAP;
using ASP.Implementation.UseCasesIm.CommandsIm.CategoryIm;
using ASP.Aplication.UseCasesAp.QueryAp.FoodQ;
using ASP.Aplication.UseCasesAp.QueryAp.AuditQ;
using ASP.Aplication.UseCasesAp.QueryAp.Contact;
using ASP.Aplication.UseCasesAp.QueryAp.CategoryQ;
using ASP.Aplication.UseCasesAp.QueryAp.RecipeQ;
using ASP.Aplication.DTO.Search;
using ASP.Implementation.Validators.CategoryValFolder;
using ASP.Implementation.Validators.ReactionValFolder;
using ASP.Implementation.Validators.RateValFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();
builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings.Jwt);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<TheContext>();
builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IAplicationProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<TheContext>();

    return new JwtAplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IAplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IAplicationProvider>().GetActor();
});

//KOMANDE
//user
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
builder.Services.AddTransient<RegisterUserDtoValidator>();
builder.Services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();
builder.Services.AddTransient<EditUserDtoValidator>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
builder.Services.AddTransient<DeleteUserDtoValidator>();
//Food
builder.Services.AddTransient<ICreateFoodCommand, EfInsertFoodDtoCommand>();
builder.Services.AddTransient<FoodDtoValidator>();
builder.Services.AddTransient<IUpdateFoodCommand, EfUpdateFoodCommand>();
builder.Services.AddTransient<UpdateFoodDtoValidator>();
builder.Services.AddTransient<IDeleteFoodCommand, EfDeleteFoodCommand>();
builder.Services.AddTransient<DeleteFoodDtoValidator>();

//Comment
builder.Services.AddTransient<ICreateCommentCommand, EFInsertCommentCommand>();
builder.Services.AddTransient<CommentDtoValidator>();
builder.Services.AddTransient<IUpdateCommentCommand, EFEditCommentCommand>();
builder.Services.AddTransient<UpdateCommentDtoValidator>();
builder.Services.AddTransient<IDeleteCommentCommand, EFDeleteCommentDtoCommand>();
builder.Services.AddTransient<DeleteCommentDtoValidator>();

//Recipe
builder.Services.AddTransient<ICreateRecipeCommand, EFInsertRecipeCommand>();
builder.Services.AddTransient<RecipeDtoValidator>();
builder.Services.AddTransient<IUpdateRecipeCommand, EfUpdateRecipeCommand>();
builder.Services.AddTransient<UpdateRecipeDtoValidator>();
builder.Services.AddTransient<IDeleteRecipeCommand, EfDeleteRecipeCommand>();
builder.Services.AddTransient<DeleteRecipeDtoValidator>();

//Rate
builder.Services.AddTransient<ICreateRateCommand, EfInsertRateCommand>();
builder.Services.AddTransient<RateDtoValidator>();
builder.Services.AddTransient<IUpdateRateCommand, EfUpdateRateCommand>();
builder.Services.AddTransient<UpdateRateValidator>();
builder.Services.AddTransient<IDeleteRateCommand, EfDeleteRateCommand>();
builder.Services.AddTransient<DeleteRateValidator>();

//Reaction
builder.Services.AddTransient<ICreateReactionCommand, EfInsertReactionCommand>();
builder.Services.AddTransient<ReactionDtoValidator>();
builder.Services.AddTransient<IUpdateReactionCommand, EfUpdateReactionCommand>();
builder.Services.AddTransient<UpdateReactionValidator>();
builder.Services.AddTransient<IDeleteReactionCommand, EfDeleteReactionCommand>();
builder.Services.AddTransient<DeleteReactionValidator>();

//kontakt
builder.Services.AddTransient<ICreateContactCommand, EfInsertContactCommand>();
builder.Services.AddTransient<CreateContactValidation>();


//mejl
builder.Services.AddTransient<IUseCaseLogger, UseCaseLogger>();
builder.Services.AddTransient<IEmailService, SmtpEmailSender>();
builder.Services.AddScoped<EmailSettings>();

//kategorije
builder.Services.AddTransient<ICreateCategoryCommand, EfInsertCategoryCommand>();
builder.Services.AddTransient<CategoryDtoValidator>();
builder.Services.AddTransient<IUpdateCategoryCommand, EfUpdateCatregoryCommand>();
builder.Services.AddTransient<UpdateCategoryValidator>();
builder.Services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
builder.Services.AddTransient<DeleteCategoryValidator>();

//query
builder.Services.AddTransient<IGetFoodQuery, EfGetFoodQuery>();
builder.Services.AddTransient<IGetAuditQuery, EfGetAudit>();
builder.Services.AddTransient<IGetContactQuery, EfGetContactQuery>();
builder.Services.AddTransient<IGetRecipeQuery, EfGetRecipeQuery>();
builder.Services.AddTransient<IGetCategoryQuery, EfCategoryQuery>();














builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            //Token dohvatamo iz Authorization header-a

            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }


            return Task.CompletedTask;

        }
    };
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
