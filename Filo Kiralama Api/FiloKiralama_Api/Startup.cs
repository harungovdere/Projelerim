using FiloKiralama_Api.Models.DapperContext;
using FiloKiralama_Api.Repositories;
using FiloKiralama_Api.Repositories.BrandsRepository;
using FiloKiralama_Api.Repositories.CarImageRepository;
using FiloKiralama_Api.Repositories.CarStatusRepository;
using FiloKiralama_Api.Repositories.InsuranceRepository;
using FiloKiralama_Api.Repositories.UsersRepository;
using FiloKiralama_Api.Repositories.ModelsRepository;
using FiloKiralama_Api.Repositories.ModelYearRepository;
using FiloKiralama_Api.Repositories.RentalCarReservedRepository;
using FiloKiralama_Api.Repositories.SecondHandAppointmentRepository;
using FiloKiralama_Api.Repositories.FleetRentalRequestRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiloKiralama_Api.Repositories.SecondHandPricingRepository;
using FiloKiralama_Api.Repositories.SecondHandSalesRepository;
using FiloKiralama_Api.Repositories.RentalCarPricingRepository;
using FiloKiralama_Api.Repositories.DailyRentalCarsRepository;
using FiloKiralama_Api.Repositories.FleetRentCustomersRepository;
using Microsoft.EntityFrameworkCore;
using FiloKiralama_Api.Repositories.SoldCarsRepository;
using FiloKiralama_Api.Repositories.FleetOffer;
using FiloKiralama_Api.Repositories.FleetRentalRepository;
using FiloKiralama_Api.Repositories.CarReturnRepository;
using FiloKiralama_Api.Repositories.MemberTransactionsRepository;



namespace FiloKiralama_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Context>();//eklendi
            services.AddTransient<ICarRepository, CarRepository>();//eklendi
            services.AddTransient<IInsuranceRepository, InsuranceRepository>();//eklendi
            services.AddTransient<IBrandRepository, BrandRepository>();//eklendi
            services.AddTransient<IModelRepository, ModelRepository>();//eklendi
            services.AddTransient<ICarStatusRepository, CarStatusRepository>();//eklendi
            services.AddTransient<IModelYearRepository, ModelYearRepository>();//eklendi
            services.AddTransient<ICarImageRepository, CarImageRepository>();//eklendi
            services.AddTransient<IUsersRepository, UsersRepository>();//eklendi
            services.AddTransient<IRentalCarReservedRepository,RentalCarReservedRepository>();//eklendi
            services.AddTransient<ISecondHandAppointmentRepository,SecondHandAppointmentRepository>();//eklendi
            services.AddTransient<IFleetRentalRequestRepository, FleetRentalRequestRepository>();//eklendi
            services.AddTransient<ISecondHandPricingRepository,SecondHandPricingRepository>();//eklendi
            services.AddTransient<ISecondHandSalesRepository,SecondHandSalesRepository>();//eklendi
            services.AddTransient<IRentalCarPricingRepository,RentalCarPricingRepository>();//eklendi
            services.AddTransient<IDailyRentalCars,DailyRentalCarsRepository>();//eklendi
            services.AddTransient<IFleetRentCustomersRepository,FleetRentCustomersRepository>();//eklendi
            services.AddTransient<ISoldCarsRepository,SoldCarsRepository>();//eklendi
            services.AddTransient<IFleetOfferRepository,FleetOfferRepository>();//eklendi
            services.AddTransient<IFleetRentalRepository,FleetRentalRepository>();//eklendi
            services.AddTransient<ICarReturnRepository,CarReturnRepository>();//eklendi
            services.AddTransient<IMemberTransactions,MemberTransactionsRepository>();//eklendi
            
            services.AddHttpContextAccessor();

            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FiloKiralama_Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());// eklendi
            });

            //services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("connection")));//eklendi--
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FiloKiralama_Api v1"));
                
            }
            app.UseStaticFiles();//eklendi
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
