using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FiloKiralama_UI.Models.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text.Encodings.Web;
using System.Text.Unicode;


namespace FiloKiralama_UI
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
            services.AddHttpClient();//eklendi
            services.AddControllers().AddNewtonsoftJson();//eklendi
            services.AddControllersWithViews().AddNewtonsoftJson();//eklendi
            services.AddRazorPages().AddNewtonsoftJson();//eklendi
            services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));// karakter sorunu için eklendi
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(x=>
                {
                    x.Cookie.Name = "NetCoreMvc.Auth";
                    x.LoginPath = "/Default/Login";
            });//eklendi
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });//eklendi
           
            services.AddControllersWithViews();
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateCarValidator>());

            //services.AddDefaultIdentity()
            //.AddRoles()
            //.AddEntityFrameworkStores();

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //options.SignIn.RequireConfirmedAccount = true);
            //services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("connection")));//eklendi--
            //services.AddDefaultIdentity<CreateMemberDto>(options => options.SignIn.RequireConfirmedAccount=true);//eklendi--

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();// eklendi
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
